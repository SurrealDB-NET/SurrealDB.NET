using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class NewExpressionTranslator
{
	internal static string Translate(NewExpression newExpression) // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
	{
		return newExpression.NodeType switch
		{
			ExpressionType.New => TranslateProjection(newExpression),
			ExpressionType.MemberInit => TranslateSubObject(newExpression),
			_ => throw new NotSupportedException($"Expression type {newExpression.NodeType} is not supported.")
		};
	}

	internal static string TranslateProjection(NewExpression newExpression)
	{
		var projections = new StringBuilder();

		for (var i = 0; i < newExpression.Arguments.Count; i++)
		{
			Expression argument = newExpression.Arguments[i];
			MemberInfo? member = newExpression.Members![i];

			switch (argument)
			{
				case ParameterExpression:
					projections.Append("*, ");

					break;

				case MemberExpression memberExpression:
					projections.Append($"{MemberExpressionTranslator.Translate(memberExpression)} AS {member!.Name}, ");

					break;

				case MethodCallExpression methodCallExpression:
					projections.Append($"{MethodCallExpressionTranslator.Translate(methodCallExpression)} AS {member!.Name}, ");

					break;

				case NewExpression subObject:
					projections.Append($"{TranslateSubObject(subObject)} AS {member?.Name}, ");

					break;

				default:
					projections.Append($"{ExpressionTranslator.Translate(argument)} AS {member!.Name}, ");

					break;
			}
		}

		projections.Remove(projections.Length - 2, 2);

		return projections.ToString();
	}

	internal static string TranslateSetter(NewExpression body)
	{
		var setters = new StringBuilder();

		for (var i = 0; i < body.Arguments.Count; i++)
		{
			Expression argument = body.Arguments[i];
			MemberInfo member = body.Members![i];

			setters.Append($"{member.Name} = {ExpressionTranslator.Translate(argument)}, ");
		}

		setters.Remove(setters.Length - 2, 2);

		return setters.ToString();
	}

	internal static string TranslateSubObject(NewExpression newExpression)
	{
		if (newExpression.Type.IsGenericType && newExpression.Type.GetGenericTypeDefinition() == typeof(None<>))
		{
			return "none";
		}

		var @object = new StringBuilder("{");

		for (var i = 0; i < newExpression.Arguments.Count; ++i)
		{
			string key = newExpression.Members![i].Name;
			Expression value = newExpression.Arguments[i];

			@object.Append($"{key}: {ExpressionTranslator.Translate(value)}, ");
		}

		@object.Remove(@object.Length - 2, 2);

		return @object.Append('}').ToString();
	}
}

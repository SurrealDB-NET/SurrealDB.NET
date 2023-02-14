using System.Linq.Expressions;
using System.Text;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class MemberInitExpressionTranslator
{
	internal static string Translate(MemberInitExpression memberInitExpression)
	{
		var setter = new StringBuilder();

		foreach (MemberBinding binding in memberInitExpression.Bindings)
		{
			var memberAssignment = (MemberAssignment)binding;

			setter.Append($"{memberAssignment.Member.Name} = {ExpressionTranslator.Translate(memberAssignment.Expression)}, ");
		}

		setter.Remove(setter.Length - 2, 2);

		return setter.ToString();
	}
}

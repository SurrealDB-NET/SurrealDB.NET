using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class ExpressionTranslator
{
	internal static string Translate(Expression expression)
	{
		return expression switch
		{
			NewExpression newExpression => NewExpressionTranslator.TranslateSubObject(newExpression),
			MethodCallExpression methodCallExpression => MethodCallExpressionTranslator.Translate(methodCallExpression),
			ConstantExpression constantExpression => ConstantExpressionTranslator.Translate(constantExpression),
			NewArrayExpression newArrayExpression => NewArrayExpressionTranslator.Translate(newArrayExpression),
			MemberExpression memberExpression => MemberExpressionTranslator.Translate(memberExpression),
			ListInitExpression listInitExpression => ListInitExpressionTranslator.Translate(listInitExpression),
			BinaryExpression binaryExpression => BinaryExpressionTranslator.Translate(binaryExpression),
			UnaryExpression unaryExpression => UnaryExpressionTranslator.Translate(unaryExpression),
			MemberInitExpression memberInitExpression => MemberInitExpressionTranslator.Translate(memberInitExpression),
			ParameterExpression parameterExpression => ParameterExpressionTranslator.Translate(parameterExpression),
			_ => throw new NotImplementedException()
		};
	}
}

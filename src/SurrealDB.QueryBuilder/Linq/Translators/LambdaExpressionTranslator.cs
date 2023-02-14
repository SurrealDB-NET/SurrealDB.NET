using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class LambdaExpressionTranslator
{
	internal static string Translate(LambdaExpression lambdaExpression)
	{
		return lambdaExpression.Body.NodeType switch
		{
			ExpressionType.New => NewExpressionTranslator.Translate((NewExpression)lambdaExpression.Body),
			ExpressionType.MemberAccess =>
				MemberExpressionTranslator.Translate((MemberExpression)lambdaExpression.Body),
			ExpressionType.MemberInit => MemberInitExpressionTranslator.Translate((MemberInitExpression)lambdaExpression.Body),
			_ => ExpressionTranslator.Translate(lambdaExpression.Body)
		};
	}
}

namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class LambdaExpressionTranslator
{
    internal static string Translate(LambdaExpression lambdaExpression)
        => lambdaExpression.Body.NodeType switch
        {
            ExpressionType.New => NewExpressionTranslator.Translate((NewExpression)lambdaExpression.Body),
            ExpressionType.MemberAccess => MemberExpressionTranslator.Translate((MemberExpression)lambdaExpression.Body),
            ExpressionType.MemberInit => MemberInitExpressionTranslator.Translate((MemberInitExpression)lambdaExpression.Body),
            _ => ExpressionTranslator.Translate(lambdaExpression.Body)
        };
}

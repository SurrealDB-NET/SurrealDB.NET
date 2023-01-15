using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class UnaryExpressionTranslator
{
    internal static string Translate(UnaryExpression unaryExpression)
        => unaryExpression.NodeType switch
        {
            ExpressionType.Convert => ExpressionTranslator.Translate(unaryExpression.Operand),
            ExpressionType.Not => $"({ExpressionTranslator.Translate(unaryExpression.Operand)} == false)",
            _ => throw new NotImplementedException()
        };
}

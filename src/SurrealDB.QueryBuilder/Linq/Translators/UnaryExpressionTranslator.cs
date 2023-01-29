namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class UnaryExpressionTranslator
{
    internal static string Translate(UnaryExpression unaryExpression)
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        => unaryExpression.NodeType switch
        {
            ExpressionType.Convert => ExpressionTranslator.Translate(unaryExpression.Operand),
            ExpressionType.Not => $"({ExpressionTranslator.Translate(unaryExpression.Operand)} == false)",
            _ => throw new NotImplementedException()
        };
}

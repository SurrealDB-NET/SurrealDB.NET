namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class NewArrayExpressionTranslator
{
    internal static string Translate(NewArrayExpression expression)
        => $"[{string.Join(", ", expression.Expressions.Select(ExpressionTranslator.Translate))}]";
}

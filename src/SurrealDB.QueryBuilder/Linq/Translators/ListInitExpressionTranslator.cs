namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class ListInitExpressionTranslator
{
    internal static string Translate(ListInitExpression expression)
        => $"[{string.Join(", ", expression.Initializers.Select(i => ExpressionTranslator.Translate(i.Arguments[0])))}]";
}

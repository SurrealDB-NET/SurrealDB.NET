namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;
using QueryBuilder.Translators;

internal static class ConstantExpressionTranslator
{
    internal static string Translate(ConstantExpression expression)
        => ObjectTranslator.Translate(expression.Value);
}

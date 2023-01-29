namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class ParameterExpressionTranslator
{
    internal static string Translate(ParameterExpression parameterExpression)
        => parameterExpression.ToString();
}

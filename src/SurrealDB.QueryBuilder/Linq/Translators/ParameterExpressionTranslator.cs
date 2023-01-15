using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal class ParameterExpressionTranslator
{
    internal static string Translate(ParameterExpression parameterExpression)
        => parameterExpression.ToString();
}

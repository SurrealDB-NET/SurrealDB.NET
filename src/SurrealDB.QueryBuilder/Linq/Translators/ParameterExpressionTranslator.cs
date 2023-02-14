using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class ParameterExpressionTranslator
{
	internal static string Translate(ParameterExpression parameterExpression)
	{
		return parameterExpression.ToString();
	}
}

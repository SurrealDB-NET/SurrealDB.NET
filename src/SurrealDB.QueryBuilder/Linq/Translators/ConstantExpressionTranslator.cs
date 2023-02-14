using System.Linq.Expressions;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class ConstantExpressionTranslator
{
	internal static string Translate(ConstantExpression expression)
	{
		return ObjectTranslator.Translate(expression.Value);
	}
}

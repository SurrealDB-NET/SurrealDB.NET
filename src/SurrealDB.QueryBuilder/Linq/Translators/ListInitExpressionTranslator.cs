using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class ListInitExpressionTranslator
{
	internal static string Translate(ListInitExpression expression)
	{
		return $"[{string.Join(", ", expression.Initializers.Select(i => ExpressionTranslator.Translate(i.Arguments[0])))}]";
	}
}

using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class NewArrayExpressionTranslator
{
	internal static string Translate(NewArrayExpression expression)
	{
		return $"[{string.Join(", ", expression.Expressions.Select(ExpressionTranslator.Translate))}]";
	}
}

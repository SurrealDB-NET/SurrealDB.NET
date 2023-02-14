using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class MemberExpressionTranslator
{
	internal static string Translate(MemberExpression memberExpression)
	{
		return memberExpression.Expression is MemberExpression subMemberExpression
			? $"{Translate(subMemberExpression)}.{memberExpression.Member.Name}"
			: memberExpression.Member.Name;
	}
}

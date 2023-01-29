namespace SurrealDB.QueryBuilder.Linq.Translators;

using System.Linq.Expressions;

internal static class MemberExpressionTranslator
{
    internal static string Translate(MemberExpression memberExpression)
        => memberExpression.Expression is MemberExpression subMemberExpression
            ? $"{Translate(subMemberExpression)}.{memberExpression.Member.Name}"
            : memberExpression.Member.Name;
}

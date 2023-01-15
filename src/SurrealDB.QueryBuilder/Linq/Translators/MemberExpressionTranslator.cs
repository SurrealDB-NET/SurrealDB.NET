using System.Linq.Expressions;

namespace SurrealDB.QueryBuilder.Linq.Translators;

internal static class MemberExpressionTranslator
{
    internal static string Translate(MemberExpression memberExpression)
    {
        if (memberExpression.Expression is MemberExpression subMemberExpression)
            return $"{Translate(subMemberExpression)}.{memberExpression.Member.Name}";
        else
            return memberExpression.Member.Name;
    }
}

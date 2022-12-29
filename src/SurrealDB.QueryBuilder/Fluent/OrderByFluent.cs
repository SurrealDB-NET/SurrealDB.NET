using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class OrderByFluent : LimitByFluent, IOrderByFluent
{
    internal OrderByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ILimitByFluent LimitBy(int limit)
    {
        Query.Append($" LIMIT {limit}");
        return new LimitByFluent(Query);
    }
}
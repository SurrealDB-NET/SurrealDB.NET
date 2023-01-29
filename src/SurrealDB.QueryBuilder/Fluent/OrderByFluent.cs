namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class OrderByFluent : LimitByFluent, IOrderByFluent
{
    internal OrderByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ILimitByFluent LimitBy(uint limit)
    {
        Query.Append($" LIMIT {limit}");
        return new LimitByFluent(Query);
    }
}

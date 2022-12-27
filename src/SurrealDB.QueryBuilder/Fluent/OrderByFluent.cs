using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class OrderByFluent : LimitByFluent, IOrderByFluent
{
    internal OrderByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public ILimitByFluent LimitBy(int limit)
    {
        _query.Append($" LIMIT {limit}");
        return new LimitByFluent(_query);
    }
}
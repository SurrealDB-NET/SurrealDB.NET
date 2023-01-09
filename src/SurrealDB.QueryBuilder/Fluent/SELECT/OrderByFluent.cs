using System.Text;

namespace SurrealDB.QueryBuilder.Fluent.Select.Implementation;

internal class OrderByFluent : LimitByFluent, IOrderByFluent
{
    internal OrderByFluent(StringBuilder currentQuery)
        : base(currentQuery)
    {
    }

    public ILimitByFluent LimitBy(uint limit)
    {
        query.Append($" LIMIT {limit}");
        return new LimitByFluent(query);
    }
}

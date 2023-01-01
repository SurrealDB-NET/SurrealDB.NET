using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class LimitByFluent : StartAtFluent, ILimitByFluent
{
    internal LimitByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IStartAtFluent StartAt(uint startAt)
    {
        query.Append($" START {startAt}");
        return new StartAtFluent(query);
    }
}

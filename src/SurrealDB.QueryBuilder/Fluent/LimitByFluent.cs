namespace SurrealDB.QueryBuilder.Fluent;

using System.Text;
using IFluent;

internal class LimitByFluent : StartAtFluent, ILimitByFluent
{
    internal LimitByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IStartAtFluent StartAt(uint startAt)
    {
        Query.Append($" START {startAt}");
        return new StartAtFluent(Query);
    }
}

using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

internal class LimitByFluent : StartAtFluent, ILimitByFluent
{
    internal LimitByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IStartAtFluent StartAt(int startAt)
    {
        Query.Append($" START {startAt}");
        return new StartAtFluent(Query);
    }
}

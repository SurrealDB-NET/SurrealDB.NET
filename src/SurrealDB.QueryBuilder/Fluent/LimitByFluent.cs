using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class LimitByFluent : StartAtFluent, ILimitByFluent
{
    internal LimitByFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IStartAtFluent StartAt(int startAt)
    {
        _query.Append($" START {startAt}");
        return new StartAtFluent(_query);
    }
}

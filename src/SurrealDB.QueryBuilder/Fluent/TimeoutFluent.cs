using System.Text;
using SurrealDB.QueryBuilder.IFluent;

namespace SurrealDB.QueryBuilder.Fluent;

internal class TimeoutFluent : ParallelFluent, ITimeoutFluent
{
    internal TimeoutFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IParallelFluent Parallel()
    {
        _query.Append(" PARALLEL");
        return new ParallelFluent(_query);
    }
}
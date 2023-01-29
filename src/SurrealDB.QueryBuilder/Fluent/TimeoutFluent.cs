using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

using IFluent;

internal class TimeoutFluent : ParallelFluent, ITimeoutFluent
{
    internal TimeoutFluent(StringBuilder currentQuery)
        : base(currentQuery) { }

    public IParallelFluent Parallel()
    {
        query.Append(" PARALLEL");
        return new ParallelFluent(query);
    }
}
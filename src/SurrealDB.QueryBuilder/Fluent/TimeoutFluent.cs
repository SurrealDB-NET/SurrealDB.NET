using System.Text;

namespace SurrealDB.QueryBuilder.Fluent;

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
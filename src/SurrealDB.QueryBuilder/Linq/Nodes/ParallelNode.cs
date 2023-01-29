namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Text;
using Statements;

internal class ParallelNode : Executor, IParallelStatement
{
    internal ParallelNode(StringBuilder query)
        : base(query) { }

    public Executor Parallel()
        => new(Query.Append(" PARALLEL"));
}

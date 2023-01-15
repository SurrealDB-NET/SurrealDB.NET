using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class ParallelNode : Executor, IParallelStatement
{
    internal ParallelNode(StringBuilder query)
        : base(query) { }

    public Executor Parallel()
        => new(_query.Append(" PARALLEL"));
}

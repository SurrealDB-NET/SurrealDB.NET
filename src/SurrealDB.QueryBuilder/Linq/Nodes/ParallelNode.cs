using System.Text;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class ParallelNode : Executor, IParallelStatement
{
	internal ParallelNode(StringBuilder query)
		: base(query) { }

	public Executor Parallel()
	{
		return new Executor(Query.Append(" PARALLEL"));
	}
}

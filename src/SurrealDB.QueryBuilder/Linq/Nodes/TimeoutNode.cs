using System.Text;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Linq.Statements;

namespace SurrealDB.QueryBuilder.Linq.Nodes;

internal class TimeoutNode : ParallelNode, ITimeoutStatement
{
	internal TimeoutNode(StringBuilder query)
		: base(query) { }

	public IParallelStatement Timeout(Duration timeoutDuration)
		=> new ParallelNode(Query.Append($" TIMEOUT {timeoutDuration}"));
}

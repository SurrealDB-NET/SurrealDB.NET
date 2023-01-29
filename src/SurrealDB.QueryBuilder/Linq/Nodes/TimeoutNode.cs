namespace SurrealDB.QueryBuilder.Linq.Nodes;

using System.Text;
using DataModels;
using Statements;

internal class TimeoutNode : ParallelNode, ITimeoutStatement
{
    internal TimeoutNode(StringBuilder query)
        : base(query) { }

    public IParallelStatement Timeout(Duration timeoutDuration)
        => new ParallelNode(Query.Append($" TIMEOUT {timeoutDuration}"));
}

namespace SurrealDB.QueryBuilder.Linq.Statements;

using DataModels;

public interface ITimeoutStatement : IParallelStatement
{
    IParallelStatement Timeout(Duration timeoutDuration);
}

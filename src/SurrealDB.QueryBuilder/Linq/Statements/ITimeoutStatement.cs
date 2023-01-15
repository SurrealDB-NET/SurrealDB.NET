using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface ITimeoutStatement : IParallelStatement
{
    IParallelStatement Timeout(Duration timeoutDuration);
}

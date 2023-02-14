namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IParallelStatement : IExecute
{
	Executor Parallel();
}

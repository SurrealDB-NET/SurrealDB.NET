namespace SurrealDB.QueryBuilder.Linq.Statements;

public interface IExecute
{
	string ExecuteAsync<T>();
}

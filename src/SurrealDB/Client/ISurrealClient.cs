namespace SurrealDB.Client;

public interface ISurrealClient
{
    public Task<TResult> ExecuteSqlAsync<TResult>(string sql) where TResult : class;
}

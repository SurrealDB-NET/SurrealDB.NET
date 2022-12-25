namespace SurrealDB.Client;

public interface ISurrealClient
{
    public Task<TResult> ExecuteSqlAsync<TResult>(string sql, CancellationToken cancellationToken = default) where TResult : class;
}

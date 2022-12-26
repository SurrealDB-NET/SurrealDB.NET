namespace SurrealDB.Client;

public interface ISurrealClient
{
    public Task<TRecord> CreateRecordAsync<TRecord>(string tableName, string content, CancellationToken cancellationToken = default) where TRecord : class;

    public Task<TResult> ExecuteSqlAsync<TResult>(string sql, CancellationToken cancellationToken = default) where TResult : class;

    public Task<IEnumerable<TRecord>> GetAllRecordsAsync<TRecord>(string tableName, CancellationToken cancellationToken = default) where TRecord : class;
}

namespace SurrealDB.Client.Rpc;

public class SurrealRpcClient : ISurrealClient
{
    public SurrealRpcClient(Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        throw new NotImplementedException();
    }

    public Task<TRecord> CreateRecordAsync<TRecord>(string tableName, string content, CancellationToken cancellationToken = default)
        where TRecord : class
    {
        throw new NotImplementedException();
    }

    public Task<TRecord> CreateRecordAsync<TRecord>(string tableName, string id, string content, CancellationToken cancellationToken = default)
        where TRecord : class
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllRecordsAsync(string tableName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> ExecuteSqlAsync<TResult>(string sql, CancellationToken cancellationToken = default)
        where TResult : class
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TRecord>> GetAllRecordsAsync<TRecord>(string tableName, CancellationToken cancellationToken = default)
        where TRecord : class
    {
        throw new NotImplementedException();
    }

    public Task<TRecord?> GetRecordByIdAsync<TRecord>(string tableName, string id, CancellationToken cancellationToken = default)
        where TRecord : class
    {
        throw new NotImplementedException();
    }

    public Task<TRecord> UpsertRecordAsync<TRecord>(string tableName, string id, string content, CancellationToken cancellationToken = default)
        where TRecord : class
    {
        throw new NotImplementedException();
    }
}

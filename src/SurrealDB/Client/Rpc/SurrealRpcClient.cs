namespace SurrealDB.Client.Rpc;

public class SurrealRpcClient : ISurrealClient
{
    public SurrealRpcClient(Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        throw new NotImplementedException();
    }

    public Task<TResult> ExecuteSqlAsync<TResult>(string sql) where TResult : class
    {
        throw new NotImplementedException();
    }
}

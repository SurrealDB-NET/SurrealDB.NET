namespace SurrealDB.Client;

public interface ISurrealClient
{
    /// <summary>
    ///     Creates a record in a specific table in the database. It is equivalent to the POST /key/:table endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to insert to</param>
    /// <param name="content">A SurrealQL object that will be passed to the CONTENT keyword</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TRecord">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TRecord> CreateRecordAsync<TRecord>(string tableName, string content, CancellationToken cancellationToken = default) where TRecord : class;

    /// <summary>
    ///     Execute a SurrealQL query. It is equivalent to the POST /sql endpoint.
    /// </summary>
    /// <param name="sql">The SurrealQL query to execute</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult> ExecuteSqlAsync<TResult>(string sql, CancellationToken cancellationToken = default) where TResult : class;

    /// <summary>
    /// 	Selects all records in a table from the database. It is equivalent to the GET /key/:table endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to select from</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TRecord">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TRecord>> GetAllRecordsAsync<TRecord>(string tableName, CancellationToken cancellationToken = default) where TRecord : class;
}

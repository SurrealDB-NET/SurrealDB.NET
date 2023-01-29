namespace SurrealDB.Client.Rpc;

public interface ISurrealRpcClient
{
    /// <summary>
    ///     Create a new record in the database.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to create the record in.</param>
    /// <param name="data">The data to create the record with.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> CreateRecordAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Delete a record or table.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to delete.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> DeleteAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    ///     Execute a SQL query.
    /// </summary>
    /// <param name="query">The SurrealQL query to execute</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    ///     Execute a SQL query.
    /// </summary>
    /// <param name="query">The SurrealQL query to execute</param>
    /// <param name="parameters">The parameters to use for this query</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, IDictionary<string, object> parameters, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Selects all records from a table in the database.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to select from</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> GetAllRecordsAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Select a specific record from the database.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to select from</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult?> GetRecordByIdAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Modify a record or table.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to modify.</param>
    /// <param name="data">The data to modify the record or table with.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> ModifyAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Update a record or records in a table.
    /// </summary>
    /// <param name="tableOrRecordId">The table or record ID to update</param>
    /// <param name="data">The data to update the record(s) with</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> UpdateRecordsAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
        where TResult : class;
}

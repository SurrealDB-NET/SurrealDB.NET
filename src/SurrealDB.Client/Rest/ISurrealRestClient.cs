namespace SurrealDB.Client.Rest;

public interface ISurrealRestClient
{
    /// <summary>
    ///     Creates a record in a specific table in the database. It is equivalent to the POST /key/:table endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to insert to</param>
    /// <param name="content">A SurrealQL object that will be passed to the CONTENT keyword</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> CreateRecordAsync<TResult>(string tableName, string content, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    ///     Creates a record in a specific table in the database. It is equivalent to the POST /key/:table/:id endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to insert to</param>
    /// <param name="id">The ID of the new record</param>
    /// <param name="content">A SurrealQL object that will be passed to the CONTENT keyword</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult> CreateRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Deletes all records from the specified table in the database. It is equivalent to the DELETE /key/:table endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to delete from</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task DeleteAllRecordsAsync(string tableName, CancellationToken cancellationToken = default);

    /// <summary>
    /// 	Delete a specific record from the database by its ID. It is equivalent to the DELETE /key/:table/:id endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to delete from</param>
    /// <param name="id">The ID of the record to delete</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task DeleteRecordByIdAsync(string tableName, string id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Execute a set SurrealQL statements. It is equivalent to the POST /sql endpoint.
    /// </summary>
    /// <param name="query">The SurrealQL query to execute</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Selects all records in a specific table in the database. It is equivalent to the GET /key/:table endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to select from</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<IEnumerable<TResult>> GetAllRecordsAsync<TResult>(string tableName, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Select a specific record from the database by its ID. It is equivalent to the GET /key/:table/:id endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to select from</param>
    /// <param name="id">The ID of the record to select</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult?> GetRecordByIdAsync<TResult>(string tableName, string id, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Creates or updates a single specific record in the database by its ID. If the record already exists, then only the specified fields will be updated.
    ///     It is equivalent to the PATCH /key/:table/:id endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table</param>
    /// <param name="id">The ID of the record</param>
    /// <param name="content">A SurrealQL object that will be passed to the CONTENT keyword</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult> ModifyRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
        where TResult : class;

    /// <summary>
    /// 	Creates or updates a single specific record in the database by its ID. It is equivalent to the PUT /key/:table/:id endpoint.
    /// </summary>
    /// <param name="tableName">The name of the table to upsert to</param>
    /// <param name="id">The ID of the record</param>
    /// <param name="content">A SurrealQL object that will be passed to the CONTENT keyword</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
    /// <typeparam name="TResult">The target type to deserialize to</typeparam>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<TResult> UpsertRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
        where TResult : class;
}

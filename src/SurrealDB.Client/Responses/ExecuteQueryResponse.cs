namespace SurrealDB.Client.Responses;

// ReSharper disable once ClassNeverInstantiated.Global
internal record ExecuteQueryResponse<TResult>
(
	string Detail,
	string Status,
	TResult Result,
	string Time
)
	where TResult : class;

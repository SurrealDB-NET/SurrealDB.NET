namespace SurrealDB.Client.Rest.Responses;

// ReSharper disable once ClassNeverInstantiated.Global
public record ExecuteSqlResponse<TResult>
(
    string Detail,
    string Status,
    TResult Result,
    string Time
) where TResult : class;

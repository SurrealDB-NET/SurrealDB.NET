namespace SurrealDB.Client.Rest.Responses;

public record ExecuteSqlResponse<TResult>
(
    string Status,
    TResult Result,
    string Time
) where TResult : class;
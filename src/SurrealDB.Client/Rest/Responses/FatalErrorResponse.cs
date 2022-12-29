namespace SurrealDB.Client.Rest.Responses;

// ReSharper disable once ClassNeverInstantiated.Global
public record FatalErrorResponse
(
    uint Code,
    string Description,
    string Details,
    string Information
);

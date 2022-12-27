namespace SurrealDB.Client.Rest.Responses;

public record FatalErrorResponse
(
    uint Code,
    string Description,
    string Details,
    string Information
);
namespace SurrealDB.Client.Rest.Responses;

public record ErrorResponse
(
    uint Code,
    string Description,
    string Details,
    string Information
);
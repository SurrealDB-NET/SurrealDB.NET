// ReSharper disable ClassNeverInstantiated.Global
namespace SurrealDB.Client.Rest;

internal record SurrealRestErrorResponse
(
	uint Code,
	string Description,
	string Details,
	string Information
);

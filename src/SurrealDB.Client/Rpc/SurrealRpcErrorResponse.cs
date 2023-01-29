// ReSharper disable ClassNeverInstantiated.Global

namespace SurrealDB.Client.Rpc;

internal record SurrealRpcErrorResult(int Code, string Message);

internal record SurrealRpcErrorResponse(string Id, SurrealRpcErrorResult Error);

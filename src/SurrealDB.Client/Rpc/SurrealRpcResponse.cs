// ReSharper disable ClassNeverInstantiated.Global
namespace SurrealDB.Client.Rpc;

internal record SurrealRpcResponse(string Id);

internal record SurrealRpcResponse<TResult>(string Id, TResult Result)
	where TResult : class;

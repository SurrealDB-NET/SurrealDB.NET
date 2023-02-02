using System.Net.WebSockets;
using SurrealDB.Client.Rpc;

namespace SurrealDB.Examples.Client.Rpc;

public class ExecuteSurrealQL : IExample
{
	public string Name => "Execute query with RPC client";

	public string Description => "Execute query with RPC client";

	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		var clientWebSocket = new ClientWebSocket();

		var client = new SurrealRpcClient(
			clientWebSocket, options =>
			{
				options
				   .WithAddress("ws://localhost:8000/rpc")
				   .WithDatabase("test")
				   .WithNamespace("test")
				   .WithUsername("root")
				   .WithPassword("root");
			}
		);

		IEnumerable<IEnumerable<object>> result =
			await client.ExecuteQueryAsync<IEnumerable<object>>("SELECT * FROM [1,2,3]", cancellationToken);

		foreach (IEnumerable<object> record in result)
			Console.WriteLine(record);
	}
}

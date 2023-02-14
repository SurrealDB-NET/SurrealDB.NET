using SurrealDB.Client.Rest;

namespace SurrealDB.Examples.Client.Rest;

public sealed class ExecuteSurrealQL : IExample
{
	public string Name => "Execute SurrealQL using the REST Client";

	public string Description => "This method maps directly to the POST /sql endpoint.";

	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		var httpClient = new HttpClient();

		var client = new SurrealRestClient(httpClient,
		                                   options =>
		                                   {
			                                   options
				                                   .WithAddress("http://localhost:8000")
				                                   .WithDatabase("test")
				                                   .WithNamespace("test")
				                                   .WithUsername("root")
				                                   .WithPassword("root");
		                                   });

		IEnumerable<IEnumerable<object>> result =
			await client.ExecuteQueryAsync<IEnumerable<object>>("SELECT * FROM [1,2,3]", cancellationToken);

		foreach (IEnumerable<object> record in result)
		{
			Console.WriteLine(record);
		}
	}
}

using SurrealDB.Client.Rest;

namespace SurrealDB.Examples.Client.Rest;

public sealed class GetAllRecords : IExample
{
	public string Name => "Select all records from a specific table using the REST client";

	public string Description => "This method maps directly to the GET /key/:table endpoint";

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

		IEnumerable<object> records = await client.GetAllRecordsAsync<object>("test", cancellationToken);

		foreach (object record in records)
		{
			Console.WriteLine(record);
		}
	}
}

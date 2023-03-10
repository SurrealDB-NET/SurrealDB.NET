using SurrealDB.Client.Rest;

namespace SurrealDB.Examples.Client.Rest;

public sealed class UpsertRecord : IExample
{
	public string Name => "Upsert a specific record by its ID using the REST client";

	public string Description => "This method maps directly to the PUT /key/:table/:id endpoint";

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

		const string content = @"{
            time: time::now()
        }";

		object record = await client.UpsertRecordAsync<object>("test", "test_id", content, cancellationToken);

		Console.WriteLine(record);
	}
}

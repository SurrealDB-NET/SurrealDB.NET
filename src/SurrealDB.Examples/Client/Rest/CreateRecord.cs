using SurrealDB.Client.Rest;

namespace SurrealDB.Examples.Client.Rest;

public sealed class CreateRecord : IExample
{
	public string Name => "Create a record in a specific table using the REST client";

	public string Description => "This method maps directly to the POST /key/:table and POST /key/:table/:id endpoint";

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

		const string newRecord = @"{
            time: time::now()
        }";

		IEnumerable<object> createdRecord1 =
			await client.CreateRecordAsync<object>("test", newRecord, cancellationToken);

		object createdRecord2 = await client.CreateRecordAsync<object>("test", "test_id", newRecord, cancellationToken);

		Console.WriteLine(createdRecord1);
		Console.WriteLine(createdRecord2);
	}
}

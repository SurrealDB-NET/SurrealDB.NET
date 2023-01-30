namespace SurrealDB.Examples.Client.Rest;

using SurrealDB.Client.Rest;
using SurrealDB.Examples;

public sealed class GetRecordById : IExample
{
    public string Name => "Select a specific record by its ID using the REST client";

    public string Description => "This method maps directly to the GET /key/:table/:id endpoint";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();

        var client = new SurrealRestClient(httpClient, options =>
        {
            options
                .WithAddress("http://localhost:8000")
                .WithDatabase("test")
                .WithNamespace("test")
                .WithUsername("root")
                .WithPassword("root");
        });

        var record = await client.GetRecordByIdAsync<object>("test", "k5qng7fmb0vpjqelzmt2", cancellationToken);

        Console.WriteLine(record);
    }
}

namespace SurrealDB.Client.Examples.Rest;

using Client.Rest;
using SurrealDB.Examples;

public sealed class DeleteRecordById : IExample
{
    public string Name => "Delete a specific record by its ID using the REST client";

    public string Description => "This method maps directly to the DELETE /key/:table/:id endpoint";

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

        await client.DeleteRecordByIdAsync("test", "test_id", cancellationToken);

        Console.WriteLine("OK");
    }
}

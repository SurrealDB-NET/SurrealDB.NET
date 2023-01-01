namespace SurrealDB.Examples;

using Client.Rest;

public sealed class DeleteAllRecordsWithRestClient : IExample
{
    public string Name => "Delete all records from a specific table using the REST client";

    public string Description => "This method maps directly to the DELETE /key/:table endpoint";

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

        await client.DeleteAllRecordsAsync("test", cancellationToken);

        Console.WriteLine("OK");
    }
}

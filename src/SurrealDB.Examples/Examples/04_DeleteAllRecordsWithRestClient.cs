namespace SurrealDB.Examples;

using Client.Rest;

public class DeleteAllRecordsWithRestClient : IExample
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var httpClient = new HttpClient();

        var client = new SurrealRestClient(httpClient, options =>
        {
            options
                .WithBaseAddress("http://localhost:8000")
                .WithDatabase("test")
                .WithNamespace("test")
                .WithUsername("root")
                .WithPassword("root");
        });

        await client.DeleteAllRecordsAsync("test", cancellationToken);

        Console.WriteLine("OK");
    }
}

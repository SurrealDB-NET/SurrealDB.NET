namespace SurrealDB.Examples;

using Client.Rest;

public class DeleteRecordByIdWithRestClient : IExample
{
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

namespace SurrealDB.Examples;

using Client.Rest;

public class GetRecordByIdWithRestClient : IExample
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

        var record = await client.GetRecordByIdAsync<object>("test", "k5qng7fmb0vpjqelzmt2", cancellationToken);

        Console.WriteLine(record);
    }
}

namespace SurrealDB.Examples;

using Client.Rest;

public class GetAllRecordsWithRestClient : IExample
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

        var records = await client.GetAllRecordsAsync<object>("test", cancellationToken);

        foreach (var record in records)
        {
            Console.WriteLine(record);
        }
    }
}

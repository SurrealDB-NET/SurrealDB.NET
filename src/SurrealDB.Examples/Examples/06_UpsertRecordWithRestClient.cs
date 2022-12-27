namespace SurrealDB.Examples;

using Client.Rest;

public class UpsertRecordWithRestClient : IExample
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

        const string content = @"{
            time: time::now()
        }";

        var record = await client.UpsertRecordAsync<object>("test", "test_id", content, cancellationToken);

        Console.WriteLine(record);
    }
}

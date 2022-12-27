namespace SurrealDB.Examples;

using Client.Rest;

public class PatchRecordWithRestClient : IExample
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

        const string content = @"{
            time: time::now()
        }";

        var record = await client.ModifyRecordAsync<object>("test", "test_id", content, cancellationToken);

        Console.WriteLine(record);
    }
}

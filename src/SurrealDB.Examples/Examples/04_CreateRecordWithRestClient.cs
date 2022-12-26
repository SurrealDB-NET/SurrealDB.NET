namespace SurrealDB.Examples;

using Client.Rest;

public class CreateRecordWithRestClient : IExample
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

        const string newRecord = @"{
            time: time::now()
        }";

        var createdRecord = await client.CreateRecordAsync<object>("test", newRecord, cancellationToken);

        Console.WriteLine(createdRecord);
    }
}

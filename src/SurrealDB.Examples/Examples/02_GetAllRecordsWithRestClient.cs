namespace SurrealDB.Examples;

using Client.Rest;

public class GetAllRecordsWithRestClient : IExample
{
    public string Name => "Select all records from a specific table using the REST client";
    
    public string Description => "This method maps directly to the GET /key/:table endpoint";
    
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

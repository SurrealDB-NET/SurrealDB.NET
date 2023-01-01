namespace SurrealDB.Examples;

using Client.Rest;

public sealed class ExecuteQueryWithRestClientExample : IExample
{
    public string Name => "Execute SurrealQL using the REST Client";

    public string Description => "This method maps directly to the POST /sql endpoint.";

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

        var result = await client.ExecuteSqlAsync<IEnumerable<object>>("SELECT * FROM test", cancellationToken);

        foreach (var record in result)
        {
            Console.WriteLine(record);
        }
    }
}

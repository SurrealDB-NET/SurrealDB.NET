namespace SurrealDB.Examples;

using Client.Rest;

public class ExecuteQueryWithRestClientExample : IExample
{
    public async Task RunAsync()
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

        var result = await client.ExecuteSqlAsync<IEnumerable<object>>("SELECT * FROM `test`");

        Console.WriteLine(result.First());
    }
}

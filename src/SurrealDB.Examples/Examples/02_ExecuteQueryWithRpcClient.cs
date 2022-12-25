﻿namespace SurrealDB.Examples;

using Client.Rpc;

public class ExecuteQueryWithRpcClientExample : IExample
{
    public async Task RunAsync()
    {
        var client = new SurrealRpcClient(options =>
        {
            options
                .WithBaseAddress("http://localhost:8000")
                .WithDatabase("")
                .WithNamespace("")
                .WithUsername("")
                .WithPassword("");
        });

        var result = await client.ExecuteSqlAsync<IEnumerable<object>>("SELECT * FROM `test`");

        Console.WriteLine(result);
    }
}

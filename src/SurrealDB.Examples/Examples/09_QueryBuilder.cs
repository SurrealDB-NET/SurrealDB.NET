using SurrealDB.QueryBuilder;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.Examples;

public class QueryBuilder : IExample
{
    public string Name => "SurrealQuery Builder";

    public string Description => "This example shows how to use the query builder to build a query.";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        Console.WriteLine(
            new SurrealQuery()
                .Select("id", "name")
                .From(source: "pokemon",
                      alias: "Pokemon")
                .Where("primaryType.name == \"Fire\"")
                .GroupBy("secondaryType.name")
                .OrderBy(field: "name",
                         textSortMethod: TextSortMethod.Collate,
                         sortOrder: SortOrder.DESC)
                .LimitBy(10)
                .StartAt(5)
                .Fetch("moveset", "evolution")
                .Timeout("30s")
                .Parallel()
                .Build());
    }
}
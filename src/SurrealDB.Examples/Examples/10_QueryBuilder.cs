using SurrealDB.QueryBuilder;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.Examples;

public class QueryBuilder : IExample
{
    public string Name => throw new NotImplementedException();

    public string Description => throw new NotImplementedException();

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        Console.WriteLine(
            new SurrealQuery()
                .Select("id", "name")
                .From(source: "pokemon",
                      alias: "Pokemon")
                .Where(predicate: "primaryType.name == \"Fire\"")
                .OrderBy(field: "name",
                         textSortMethod: TextSortMethod.Collate,
                         sortOrder: SortOrder.DESC)
                .LimitBy(10)
                .StartAt(5)
                .Fetch("moveset")
                .Timeout("30s")
                .Parallel()
                .Build());
    }
}
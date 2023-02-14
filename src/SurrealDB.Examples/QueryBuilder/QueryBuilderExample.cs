using SurrealDB.QueryBuilder;
using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.Examples.QueryBuilder;

public sealed class QueryBuilder : IExample
{
	public string Name => "SurrealQL builder";

	public string Description => "Build a SurrealQL query using the SurrealQL builder";

	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		await Task.CompletedTask;

		Console.WriteLine(SurrealQL
		                  .Select("id", "name")
		                  .From("pokemon",
		                        "Pokemon")
		                  .Where("primaryType.name == \"Fire\"")
		                  .GroupBy("secondaryType.name")
		                  .OrderBy("name",
		                           textSortMethod: TextSortMethod.Collate,
		                           sortOrder: SortOrder.Desc)
		                  .LimitBy(10)
		                  .StartAt(5)
		                  .Fetch("moveset", "evolution")
		                  .Timeout("30s")
		                  .Parallel()
		                  .Build());
	}
}

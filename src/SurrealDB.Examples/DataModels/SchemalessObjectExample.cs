using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.Examples.DataModels;

public sealed class SchemalessObjectExample : IExample
{
	public string Name => "Schemaless object data model";

	public string Description => "Create a schemaless object and print it to the console using the ToString method";

	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		var obj = new SchemalessObject
		{
			{ "name", "John Doe" },
			{ "age", 42 },
			{ "isAlive", true },
			{ "spouse", null },
			{
				"address", new SchemalessObject
				{
					{ "street", "123 Main St" },
					{ "city", "Anywhere" },
					{ "state", "CA" },
					{ "zip", "12345" }
				}
			},
			{ "phoneNumbers", new[] { "123-456-7890", "234-567-8901" } },
			{
				"children", new[]
				{
					new SchemalessObject
					{
						{ "name", "Jane Doe" },
						{ "age", 13 }
					},
					new SchemalessObject
					{
						{ "name", "John Doe" },
						{ "age", 10 }
					}
				}
			},
			{
				"pets", new[]
				{
					new SchemalessObject
					{
						{ "name", "Fluffy" },
						{ "type", "Dog" }
					}
				}
			},
			{
				"extraInfo", new SchemalessObject
				{
					{ "favoriteColor", "blue" },
					{ "favoriteNumbers", new[] { 1, 2, 3, 4, 5 } },
					{
						"favoriteFoods", new[]
						{
							new SchemalessObject
							{
								{ "name", "pizza" }
							},
							new SchemalessObject
							{
								{ "name", "ice cream" }
							}
						}
					}
				}
			}
		};

		Console.WriteLine(obj);

		await Task.CompletedTask;
	}
}

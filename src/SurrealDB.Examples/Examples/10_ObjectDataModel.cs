namespace SurrealDB.Examples;

using SurrealDB.QueryBuilder.DataModels;

public sealed class ObjectDataModel : IExample
{
    public string Name => "SurrealQL Object Data Model";

    public string Description => "Create a SurrealQL object using the Object data model class";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var obj = new Object
        {
            {"name", "John Doe"},
            {"age", 42},
            {"isAlive", true},
            {"spouse", null},
            {
                "address", new Object
                {
                    {"street", "123 Main St"},
                    {"city", "Anywhere"},
                    {"state", "CA"},
                    {"zip", "12345"}
                }
            },
            {
                "phoneNumbers", new[]
                {
                    "123-456-7890",
                    "234-567-8901"
                }
            },
            {
                "children", new[]
                {
                    new Object
                    {
                        {"name", "Jane Doe"},
                        {"age", 13}
                    },
                    new Object
                    {
                        {"name", "John Doe"},
                        {"age", 10}
                    }
                }
            },
            {
                "pets", new[]
                {
                    new Object
                    {
                        {"name", "Fluffy"},
                        {"type", "Dog"},
                    }
                }
            },
            {
                "extraInfo", new Object
                {
                    {"favoriteColor", "blue"},
                    {"favoriteNumbers", new[] {1, 2, 3, 4, 5}},
                    {
                        "favoriteFoods", new[]
                        {
                            new Object {{"name", "pizza"}},
                            new Object {{"name", "ice cream"}}
                        }
                    }
                }
            }
        };

        Console.WriteLine(obj);

        await Task.CompletedTask;
    }
}

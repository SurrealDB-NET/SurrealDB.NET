namespace SurrealDB.Examples;

using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Functions;
using SurrealDB.QueryBuilder.Translators;

public class ObjectTranslatorExample : IExample
{
    public string Name => "Object Translator";

    public string Description => "Demonstrates how to use the ObjectTranslator to translate between objects and their database representations.";

    internal class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public Point Location { get; set; }

        public Person? BestFriend { get; set; }

        internal string? SSN { get; set; } = null!;

        public Function CurrentTime { get; set; } = null!;
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine(
            ObjectTranslator.Translate(
                new Person
                {
                    Name = "John",
                    Age = 30,
                    SSN = "123-45-6789",
                    CurrentTime = TimeFunctions.Now(),
                    Location = (1, 2),
                    BestFriend = new Person
                    {
                        Name = "Jane",
                        CurrentTime = TimeFunctions.Now(),
                        Location = (3, 4),
                        Age = 31,
                        SSN = "987-65-4321"
                    }
                }
            )
        );

        await Task.CompletedTask;
    }
}

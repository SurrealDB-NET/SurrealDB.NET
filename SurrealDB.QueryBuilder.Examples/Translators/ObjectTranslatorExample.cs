namespace SurrealDB.QueryBuilder.Examples.Translators;

using Functions;
using SurrealDB.Examples;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Translators;

public class ObjectTranslatorExample : IExample
{
    public string Name => "Object translator";

    public string Description => "Translates between objects and their database representations.";

    internal class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public Point Location { get; set; }

        public Person? BestFriend { get; set; }

        internal string? SSN { get; set; } = null!;

        public DateTimeOffset CurrentTime { get; set; }
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        // notice that SSN is not included in the output
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

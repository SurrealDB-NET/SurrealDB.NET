namespace SurrealDB.Examples.Translators;

using SurrealDB.Examples;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Functions;
using SurrealDB.QueryBuilder.Translators;

public class ObjectTranslatorExample : IExample
{
    public string Name => "Object translator";

    public string Description => "Translates between objects and their database representations.";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        // notice that SSN is not included in the output
        Console.WriteLine(
            ObjectTranslator.Translate(
                new Person
                {
                    Name = "John",
                    Age = 30,
                    Ssn = "123-45-6789",
                    CurrentTime = TimeFunctions.Now(),
                    Location = (1, 2),
                    BestFriend = new Person
                    {
                        Name = "Jane",
                        CurrentTime = TimeFunctions.Now(),
                        Location = (3, 4),
                        Age = 31,
                        Ssn = "987-65-4321"
                    }
                }
            )
        );

        await Task.CompletedTask;
    }

    internal class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public Point Location { get; set; }

        public Person? BestFriend { get; set; }

        internal string? Ssn { get; set; }

        public DateTimeOffset CurrentTime { get; set; }
    }
}

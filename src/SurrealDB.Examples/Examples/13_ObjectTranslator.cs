namespace SurrealDB.Examples;

using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Functions;
using SurrealDB.QueryBuilder.Translators;

public class ObjectTranslatorExample : IExample
{
    public string Name => "Object Translator";

    public string Description => "Demonstrates how to use the ObjectTranslator to translate between objects and their database representations.";

    internal class Person
    {
        public required string Name { get; set; }

        public required int Age { get; set; }

        public required Point Location { get; set; }

        public Person? BestFriend { get; set; }

        internal required string SSN { get; set; }

        public required Future<DateTimeOffset> CurrentTime { get; set; }
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
                    Location = (1, 2),
                    CurrentTime = CastFunctions.ToFuture(TimeFunctions.Now()),
                    BestFriend = new Person
                    {
                        Name = "Jane",
                        Location = (3, 4),
                        Age = 31,
                        SSN = "987-65-4321",
                        CurrentTime = CastFunctions.ToFuture(TimeFunctions.Round(TimeFunctions.Now(), "1w"))
                    }
                }
            )
        );

        await Task.CompletedTask;
    }
}

namespace SurrealDB.QueryBuilder.Examples.DataModels;

using SurrealDB.Examples;
using SurrealDB.QueryBuilder.DataModels;

public sealed class DurationExample : IExample
{
    public string Name => "Duration data model";

    public string Description => "Create a duration using the Duration data model class";

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        var durationFromConstructor = new Duration(4, 20, minutes: 78, nanoseconds: 1000000000); // specify the units you want to use

        Duration durationFromString = "1s2y10w10w2y78m"; // order doesn't matter, as long as the unit is specified (y, w, d, h, m, s, ms, µs, ns)

        Console.WriteLine(durationFromConstructor == durationFromString);

        Console.WriteLine(durationFromConstructor + durationFromString);

        // you can also add/subtract a duration from a DateTime or DateTimeOffset, nearly as percise as SurrealDB
        var dateTimeOffset = DateTimeOffset.UtcNow;

        Console.WriteLine((dateTimeOffset + durationFromString).ToString("o")); // ISO 8601 format

        var dateTime = DateTime.Now;

        Console.WriteLine((dateTime - durationFromConstructor).ToString("o")); // ISO 8601 format

        return Task.CompletedTask;
    }
}

namespace SurrealDB.QueryBuilder.Functions;

using Enums;
using Translators;

public static class TimeFunctions
{
    public static Function Day(string dateTime)
        => new($"time::day({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Floor(string dateTime, string duration)
        => new($"time::floor({PrimitiveTranslator.Translate(dateTime)}, {PrimitiveTranslator.Translate(duration)})");

    public static Function Group(string dateTime, TimeUnit timeUnit)
        => new($"time::group({PrimitiveTranslator.Translate(dateTime)}, {PrimitiveTranslator.Translate(timeUnit.ToString()).ToLower()})");

    public static Function Hour(string dateTime)
        => new($"time::hour({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Mins(string dateTime)
        => new($"time::mins({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Month(string dateTime)
        => new($"time::month({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Nano(string dateTime)
        => new($"time::nano({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Now()
        => new("time::now()");

    public static Function Round(string dateTime, string duration)
        => new($"time::round({PrimitiveTranslator.Translate(dateTime)}, {PrimitiveTranslator.Translate(duration)})");

    public static Function Secs(string dateTime)
        => new($"time::secs({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Unix(string dateTime)
        => new($"time::unix({PrimitiveTranslator.Translate(dateTime)})");

    public static Function WDay(string dateTime)
        => new($"time::wday({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Week(string dateTime)
        => new($"time::week({PrimitiveTranslator.Translate(dateTime)})");

    public static Function YDay(string dateTime)
        => new($"time::yday({PrimitiveTranslator.Translate(dateTime)})");

    public static Function Year(string dateTime)
        => new($"time::year({PrimitiveTranslator.Translate(dateTime)})");
}

namespace SurrealDB.QueryBuilder.Functions;

using Enums;

public static class TimeFunctions
{
    public static Function Day(string dateTime)
        => new("time::day({0})", dateTime);

    public static Function Floor(string dateTime, string duration)
        => new("time::floor({0}, {1})", dateTime, duration);

    public static Function Group(string dateTime, TimeUnit timeUnit)
        => new("time::group({0}, {1})", dateTime, timeUnit);

    public static Function Hour(string dateTime)
        => new("time::hour({0})", dateTime);

    public static Function Mins(string dateTime)
        => new("time::mins({0})", dateTime);

    public static Function Month(string dateTime)
        => new("time::month({0})", dateTime);

    public static Function Nano(string dateTime)
        => new("time::nano({0})", dateTime);

    public static Function Now()
        => new("time::now()");

    public static Function Round(string dateTime, string duration)
        => new("time::round({0}, {1})", dateTime, duration);

    public static Function Secs(string dateTime)
        => new("time::secs({0})", dateTime);

    public static Function Unix(string dateTime)
        => new("time::unix({0})", dateTime);

    public static Function WDay(string dateTime)
        => new("time::wday({0})", dateTime);

    public static Function Week(string dateTime)
        => new("time::week({0})", dateTime);

    public static Function YDay(string dateTime)
        => new("time::yday({0})", dateTime);

    public static Function Year(string dateTime)
        => new("time::year({0})", dateTime);
}

using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Functions;

public static class TimeFunction
{
    public static string Day(string datetime)
        => $"time::day('{datetime}')";

    public static string Floor(string datetime, string duration)
        => $"time::floor('{datetime}', {duration})";

    public static string Group(string datetime, TimeUnit timeUnit)
        => $"time::group('{datetime}', {timeUnit.ToString().ToLower()})";

    public static string Hour(string dateTime)
        => $"time::hour('{dateTime}')";

    public static string Mins(string dateTime)
        => $"time::mins('{dateTime}')";

    public static string Month(string dateTime)
        => $"time::month('{dateTime}')";

    public static string Nano(string dateTime)
        => $"time::nano('{dateTime}')";

    public static string Now()
        => "time::now()";

    public static string Round(string dateTime, string duration)
        => $"time::round('{dateTime}', {duration})";

    public static string Secs(string dateTime)
        => $"time::secs('{dateTime}')";

    public static string Unix(string dateTime)
        => $"time::unix('{dateTime}')";

    public static string WDay(string dateTime)
        => $"time::wday('{dateTime}')";

    public static string Week(string dateTime)
        => $"time::week('{dateTime}')";

    public static string YDay(string dateTime)
        => $"time::yday('{dateTime}')";

    public static string Year(string dateTime)
        => $"time::year('{dateTime}')";
}

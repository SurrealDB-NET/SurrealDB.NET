using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Exceptions;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

using Enums;

public static class TimeFunctions
{
    [SurrealFunction("time::now()")]
    public static DateTimeOffset Now()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::floor({0},{1})")]
    public static DateTimeOffset Floor(DateTimeOffset dateTime, Duration duration)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::round({0},{1})")]
    public static DateTimeOffset Round(DateTimeOffset dateTime, Duration duration)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::group({0},{1})")]
    public static DateTimeOffset Group(DateTimeOffset dateTime, TimeUnit timeUnit)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::unix()")]
    public static ulong Unix()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::unix({0})")]
    public static ulong Unix(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::nano()")]
    public static ulong Nano()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::nano({0})")]
    public static ulong Nano(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::secs()")]
    public static DateTimeOffset Secs()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::secs({0})")]
    public static DateTimeOffset Secs(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::mins()")]
    public static uint Mins()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::mins({0})")]
    public static uint Mins(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::hour()")]
    public static uint Hour()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::hour({0})")]
    public static uint Hour(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::day()")]
    public static uint Day()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::day({0})")]
    public static uint Day(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::wday()")]
    public static uint WDay()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::wday({0})")]
    public static uint WDay(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::yday()")]
    public static uint YDay()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::yday({0})")]
    public static uint YDay(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::week()")]
    public static uint Week()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::week({0})")]
    public static uint Week(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::month()")]
    public static uint Month()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::month({0})")]
    public static uint Month(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::year()")]
    public static uint Year()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("time::year({0})")]
    public static uint Year(DateTimeOffset dateTime)
        => throw new IllegalSurrealFunctionCallException();
}

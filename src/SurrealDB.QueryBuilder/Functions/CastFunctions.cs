using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class CastFunctions
{
    [SurrealFunction("<bool>")]
    public static bool ToBool(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<int>")]
    public static long ToInt(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<float>")]
    public static double ToFloat(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<string>")]
    public static string ToString(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<number>")]
    public static decimal ToNumber(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<decimal>")]
    public static decimal ToDecimal(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<datetime>")]
    public static DateTimeOffset ToDateTime(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<duration>")]
    public static Duration ToDuration(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<future>")]
    public static Future<TResult> ToFuture<TResult>(TResult value)
        => new(value);

    [SurrealFunction("<future>")]
    public static Future<TResult> ToFuture<TResult>(string script)
        => new(script);
}

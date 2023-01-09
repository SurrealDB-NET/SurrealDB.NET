using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class CastFunctions
{
    [SurrealFunction("<bool>{0}")]
    public static bool ToBool(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<int>{0}")]
    public static long ToInt(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<float>{0}")]
    public static double ToFloat(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<string>{0}")]
    public static string ToString(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<number>{0}")]
    public static decimal ToNumber(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<decimal>{0}")]
    public static decimal ToDecimal(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<datetime>{0}")]
    public static DateTimeOffset ToDateTime(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<duration>{0}")]
    public static Duration ToDuration(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("<future>{{0}}")]
    public static Future<TResult> ToFuture<TResult>(TResult value)
        => new(value);

    public static Future<TResult> ToFuture<TResult>(string script)
        => new(script);
}

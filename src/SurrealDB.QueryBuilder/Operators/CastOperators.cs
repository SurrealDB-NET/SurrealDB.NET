namespace SurrealDB.QueryBuilder.Functions;

using Attributes;
using DataModels;
using Exceptions;

public static class CastOperators
{
    [SurrealOperator("<bool>")]
    public static bool ToBool(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<int>")]
    public static long ToInt(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<float>")]
    public static double ToFloat(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<string>")]
    public static string ToString(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<number>")]
    public static decimal ToNumber(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<decimal>")]
    public static decimal ToDecimal(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<datetime>")]
    public static DateTimeOffset ToDateTime(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<duration>")]
    public static Duration ToDuration(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealOperator("<future>")]
    public static Future<TResult> ToFuture<TResult>(TResult value)
        => new(value);
}

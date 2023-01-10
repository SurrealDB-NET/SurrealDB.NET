using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class RandomFunctions
{
    [SurrealFunction("rand")]
    public static double Rand()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::bool")]
    public static bool Bool()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::enum")]
    public static object? Enum(params object?[] values)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::float")]
    public static double Float()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::float")]
    public static double Float(double min, double max)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::guid")]
    public static string Guid()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::guid")]
    public static string Guid(double length)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::int")]
    public static long Int()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::int")]
    public static long Int(long min, long max)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::string")]
    public static string String()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::string")]
    public static string String(uint length)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::string")]
    public static string String(uint minLength, uint maxLength)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::time")]
    public static DateTimeOffset Time()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::time")]
    public static DateTimeOffset Time(ulong minUnixTimestamp, ulong maxUnixTimestamp)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("rand::uuid")]
    public static Guid Uuid()
        => throw new IllegalSurrealFunctionCallException();
}

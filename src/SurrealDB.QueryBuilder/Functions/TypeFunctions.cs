using System.Collections;
using System.Numerics;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class TypeFunctions
{
    [SurrealFunction("type::bool")]
    public static bool Bool(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::int")]
    public static long Int(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::float")]
    public static double Float(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::string")]
    public static string String(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::number")]
    public static BigInteger Number(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::decimal")]
    public static decimal Decimal(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::duration")]
    public static Duration Duration(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::datetime")]
    public static DateTime DateTime(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::point")]
    public static Point? Point(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::point")]
    public static Point Point(double x, double y)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::regex")]
    public static string? Regex(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::table")]
    public static IEnumerable Table(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::thing")]
    public static TRecord Thing<TRecord>(object? table, object? id)
        => throw new IllegalSurrealFunctionCallException();
}

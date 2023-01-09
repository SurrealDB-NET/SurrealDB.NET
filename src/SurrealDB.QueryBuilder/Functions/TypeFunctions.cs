using System.Collections;
using System.Numerics;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class TypeFunctions
{
    [SurrealFunction("type::bool({0})")]
    public static bool Bool(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::int({0})")]
    public static long Int(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::float({0})")]
    public static double Float(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::string({0})")]
    public static string String(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::number({0})")]
    public static BigInteger Number(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::decimal({0})")]
    public static decimal Decimal(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::duration({0})")]
    public static Duration Duration(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::datetime({0})")]
    public static DateTime DateTime(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::point({0})")]
    public static Point? Point(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::point({0},{1})")]
    public static Point Point(double x, double y)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::regex({0})")]
    public static string? Regex(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::table({0})")]
    public static IEnumerable Table(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("type::thing({0})")]
    public static TRecord Thing<TRecord>(object? table, object? id)
        => throw new IllegalSurrealFunctionCallException();
}

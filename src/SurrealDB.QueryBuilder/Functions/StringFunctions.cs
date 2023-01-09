using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

public static class StringFunctions
{
    [SurrealFunction("string::length({0})")]
    public static ulong Length(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::startsWith({0},{1})")]
    public static bool StartsWith(string value, string prefix)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::endsWith({0},{1})")]
    public static bool EndsWith(string value, string suffix)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::lowercase({0})")]
    public static string Lowercase(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::uppercase({0})")]
    public static string Uppercase(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::repeat({0},{1})")]
    public static string Repeat(string value, ulong count)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::replace({0},{1},{2})")]
    public static string Replace(string value, string search, string replace)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::reverse({0})")]
    public static string Reverse(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::slice({0},{1},{2})")]
    public static string Slice(string value, long start, long end)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::slug({0})")]
    public static string Slug(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::trim({0})")]
    public static string Trim(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::concat({0})")]
    public static string Concat(params string[] values)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::join({0},{1})")]
    public static string Join(string delimiter, params string[] values)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::words({0})")]
    public static IEnumerable<string> Words(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("string::split({0},{1})")]
    public static IEnumerable<string> Split(string value, string delimiter)
        => throw new IllegalSurrealFunctionCallException();
}

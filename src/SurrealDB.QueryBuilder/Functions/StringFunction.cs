namespace SurrealDB.QueryBuilder.Functions;

public static class StringFunction
{
    public static string Concat(params string[] values)
        => $"string::concat([{string.Join(", ", values.Select(value => $"'{value}'"))}])";

    public static string EndsWith(string value, string suffix)
        => $"string::endsWith('{value}', {suffix})";

    public static string Join(string delimiter, params string[] values)
        => $"string::join({delimiter}, {string.Join(", ", values.Select(value => $"'{value}'"))})";

    public static string Length(string value)
        => $"string::length('{value}')";

    public static string Lowercase(string value)
        => $"string::lowercase('{value}')";

    public static string Repeat(string value, ulong count)
        => $"string::repeat('{value}', {count})";

    public static string Replace(string value, string search, string replace)
        => $"string::replace('{value}', '{search}', '{replace}')";

    public static string Reverse(string value)
        => $"string::reverse('{value}')";

    public static string Slice(string value, long start, long length)
        => $"string::slice('{value}', {start}, {length})";

    public static string Slug(string value)
        => $"string::slug('{value}')";

    public static string Split(string value, string delimiter)
        => $"string::split('{value}', '{delimiter}')";

    public static string StartsWith(string value, string prefix)
        => $"string::startsWith('{value}', {prefix})";

    public static string Trim(string value)
        => $"string::trim('{value}')";

    public static string Uppercase(string value)
        => $"string::uppercase('{value}')";

    public static string Words(string value)
        => $"string::words('{value}')";
}

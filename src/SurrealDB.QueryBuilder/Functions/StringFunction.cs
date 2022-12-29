namespace SurrealDB.QueryBuilder.Functions;

public static class StringFunction
{
    public static string Concat(params object[] values)
        => $"string::concat([{string.Join(", ", values)}])";

    public static string EndsWith(object value, object suffix)
        => $"string::endsWith({value}, {suffix})";

    public static string Join(object delimiter, params object[] values)
        => $"string::join({delimiter}, {string.Join(", ", values)})";

    public static string Length(object value)
        => $"string::length({value})";

    public static string Lowercase(object value)
        => $"string::lowercase({value})";

    public static string Repeat(object value, ulong count)
        => $"string::repeat({value}, {count})";

    public static string Replace(object value, object search, object replace)
        => $"string::replace({value}, {search}, {replace})";

    public static string Reverse(object value)
        => $"string::reverse({value})";

    public static string Slice(object value, int start, int length)
        => $"string::slice({value}, {start}, {length})";

    public static string Slug(object value)
        => $"string::slug({value})";

    public static string Split(object value, object delimiter)
        => $"string::split({value}, {delimiter})";

    public static string StartsWith(object value, object prefix)
        => $"string::startsWith({value}, {prefix})";

    public static string Trim(object value)
        => $"string::trim({value})";

    public static string Uppercase(object value)
        => $"string::uppercase({value})";

    public static string Words(object value)
        => $"string::words({value})";
}

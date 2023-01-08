namespace SurrealDB.QueryBuilder.Functions;

public static class StringFunctions
{
    public static Function Concat(params string[] values)
        => new("string::concat({0})", values);

    public static Function EndsWith(string value, string suffix)
        => new("string::endsWith({0}, {1})", value, suffix);

    public static Function Join(string delimiter, params string[] values)
        => new("string::join({0}, {1})", delimiter, values);

    public static Function Length(string value)
        => new("string::length({0})", value);

    public static Function Lowercase(string value)
        => new("string::lowercase({0})", value);

    public static Function Repeat(string value, ulong count)
        => new("string::repeat({0}, {1})", value, count);

    public static Function Replace(string value, string search, string replace)
        => new("string::replace({0}, {1}, {2})", value, search, replace);

    public static Function Reverse(string value)
        => new("string::reverse({0})", value);

    public static Function Slice(string value, long start, long length)
        => new("string::slice({0}, {1}, {2})", value, start, length);

    public static Function Slug(string value)
        => new("string::slug({0})", value);

    public static Function Split(string value, string delimiter)
        => new("string::split({0}, {1})", value, delimiter);

    public static Function StartsWith(string value, string prefix)
        => new("string::startsWith({0}, {1})", value, prefix);

    public static Function Trim(string value)
        => new("string::trim({0})", value);

    public static Function Uppercase(string value)
        => new("string::uppercase({0})", value);

    public static Function Words(string value)
        => new("string::words({0})", value);
}

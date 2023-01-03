namespace SurrealDB.QueryBuilder.Functions;

using Translators;

public static class StringFunctions
{
    public static Function Concat(params string[] values)
        => new($"string::concat({EnumerableTranslator.Translate(values.Select(PrimitiveTranslator.Translate))})");

    public static Function EndsWith(string value, string suffix)
        => new($"string::endsWith({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(suffix)})");

    public static Function Join(string delimiter, params string[] values)
        => new($"string::join({PrimitiveTranslator.Translate(delimiter)}, {EnumerableTranslator.Translate(values.Select(PrimitiveTranslator.Translate))})");

    public static Function Length(string value)
        => new($"string::length({PrimitiveTranslator.Translate(value)})");

    public static Function Lowercase(string value)
        => new($"string::lowercase({PrimitiveTranslator.Translate(value)})");

    public static Function Repeat(string value, ulong count)
        => new($"string::repeat({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(count)})");

    public static Function Replace(string value, string search, string replace)
        => new($"string::replace({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(search)}, {PrimitiveTranslator.Translate(replace)})");

    public static Function Reverse(string value)
        => new($"string::reverse({PrimitiveTranslator.Translate(value)})");

    public static Function Slice(string value, long start, long length)
        => new($"string::slice({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(start)}, {PrimitiveTranslator.Translate(length)})");

    public static Function Slug(string value)
        => new($"string::slug({PrimitiveTranslator.Translate(value)})");

    public static Function Split(string value, string delimiter)
        => new($"string::split({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(delimiter)})");

    public static Function StartsWith(string value, string prefix)
        => new($"string::startsWith({PrimitiveTranslator.Translate(value)}, {PrimitiveTranslator.Translate(prefix)})");

    public static Function Trim(string value)
        => new($"string::trim({PrimitiveTranslator.Translate(value)})");

    public static Function Uppercase(string value)
        => new($"string::uppercase({PrimitiveTranslator.Translate(value)})");

    public static Function Words(string value)
        => new($"string::words({PrimitiveTranslator.Translate(value)})");
}

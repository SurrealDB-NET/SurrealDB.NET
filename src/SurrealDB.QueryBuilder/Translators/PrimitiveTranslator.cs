using System.Collections;
using System.Numerics;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;

namespace SurrealDB.QueryBuilder.Translators;

/// <summary>
/// Translates a value to a string that matches the SurrealQL syntax.
/// </summary>
internal static class PrimitiveTranslator
{
    internal static string Translate(None none)
        => $"{none}";

    internal static string Translate(bool @bool)
        => @bool ? "true" : "false";

    internal static string Translate(char @char)
        => $"\"{@char}\"";

    internal static string Translate<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"{number}";

    internal static string Translate(string @string)
        => $"\"{@string}\"";

    internal static string Translate(Duration duration)
        => $"\"{duration}\"";

    internal static string Translate(DateTime dateTime)
        => $"\"{dateTime.ToString("o")}\"";

    internal static string Translate(DateTimeOffset dateTimeOffset)
        => $"\"{dateTimeOffset.ToString("o")}\"";

    internal static string Translate(IGeometry geometry)
        => $"\"{geometry}\"";
}

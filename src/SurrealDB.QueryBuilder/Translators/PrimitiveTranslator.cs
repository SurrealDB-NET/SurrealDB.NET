namespace SurrealDB.QueryBuilder.Translators;

using System.Numerics;
using DataModels;

/// <summary>
/// Translates a value to a string that matches the SurrealQL syntax.
/// </summary>
internal static class PrimitiveTranslator
{
    internal static string Translate(bool @bool)
        => @bool ? "true" : "false";

    internal static string Translate(char @char)
        => $"\"{@char}\"";

    internal static string Translate<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"{number}";

    internal static string Translate(string @string)
        => $"\"{@string}\"";
}

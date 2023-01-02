using System.Collections;

namespace SurrealDB.QueryBuilder.Translators;

internal static class ArrayTranslator
{
    internal static string Translate(IEnumerable array)
        => ArrayTranslator.Translate(array.Cast<object>());

    internal static string Translate<T>(IEnumerable<T> array)
        => $"[{string.Join(", ", array.Select(obj => ObjectTranslator.Translate(obj)))}]";

    internal static string Translate<T>(T[] array)
        => $"[{string.Join(", ", array.Select(obj => ObjectTranslator.Translate(obj)))}]";
}
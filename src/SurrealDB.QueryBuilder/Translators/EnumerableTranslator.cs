namespace SurrealDB.QueryBuilder.Translators;

using System.Collections;

internal static class EnumerableTranslator
{
    internal static string Translate(IEnumerable array)
        => Translate(array.Cast<object>());

    internal static string Translate<T>(IEnumerable<T> array)
        => $"[{string.Join(", ", array.Select(obj => ObjectTranslator.Translate(obj)))}]";

    internal static string Translate<T>(T[] array)
        => $"[{string.Join(", ", array.Select(obj => ObjectTranslator.Translate(obj)))}]";
}

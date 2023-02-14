using System.Collections;

namespace SurrealDB.QueryBuilder.Translators;

internal static class EnumerableTranslator
{
	internal static string Translate(IEnumerable array)
	{
		return Translate(array.Cast<object>());
	}

	internal static string Translate<T>(IEnumerable<T> array)
	{
		return $"[{string.Join(",", array.Select(obj => ObjectTranslator.Translate(obj)))}]";
	}

	internal static string Translate<T>(T[] array)
	{
		return $"[{string.Join(",", array.Select(obj => ObjectTranslator.Translate(obj)))}]";
	}
}

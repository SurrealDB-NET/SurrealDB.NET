using System.Numerics;

namespace SurrealDB.QueryBuilder.Translators;

/// <summary>
///     Translates a value to a string that matches the SurrealQL syntax.
/// </summary>
internal static class PrimitiveTranslator
{
	internal static string Translate(bool @bool)
	{
		return @bool ? "true" : "false";
	}

	internal static string Translate(char @char)
	{
		return $"\"{@char}\"";
	}

	internal static string Translate<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		return $"{number}";
	}

	internal static string Translate(string @string)
	{
		return $"\"{@string}\"";
	}
}

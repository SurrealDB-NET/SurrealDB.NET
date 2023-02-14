using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Translators;

internal static class DateTimeTranslator
{
	internal static string Translate(Duration duration)
	{
		return $"\"{duration}\"";
	}

	internal static string Translate(DateTime dateTime)
	{
		return $"\"{dateTime:o}\"";
	}

	internal static string Translate(DateTimeOffset dateTimeOffset)
	{
		return $"\"{dateTimeOffset:o}\"";
	}
}

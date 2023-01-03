using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Translators;

internal static class DateTimeTranslator
{
    internal static string Translate(Duration duration)
        => $"\"{duration}\"";

    internal static string Translate(DateTime dateTime)
        => $"\"{dateTime:o}\"";

    internal static string Translate(DateTimeOffset dateTimeOffset)
        => $"\"{dateTimeOffset:o}\"";
}

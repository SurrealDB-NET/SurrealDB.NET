using SurrealDB.QueryBuilder.Functions;

namespace SurrealDB.QueryBuilder.Translators;

internal static class FunctionTranslator
{
    internal static string Translate(Function function)
        => $"{function}";
}

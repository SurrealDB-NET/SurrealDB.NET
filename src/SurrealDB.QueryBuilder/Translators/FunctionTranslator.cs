namespace SurrealDB.QueryBuilder.Translators;

using Functions;

internal static class FunctionTranslator
{
    internal static string Translate(Function function)
        => $"{function}";
}

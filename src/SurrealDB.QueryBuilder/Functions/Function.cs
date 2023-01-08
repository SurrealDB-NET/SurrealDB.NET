namespace SurrealDB.QueryBuilder.Functions;

using Translators;

public class Function
{
    private string Translated { get; }

    internal Function(string function, params object[] args)
        => Translated = TranslateFunctionInvocation(function, args);

    public override string ToString()
        => Translated;

    private static object?[] TranslateFunctionArguments(params object[] args)
        => args.Select(ObjectTranslator.Translate).ToArray<object?>();

    private static string TranslateFunctionInvocation(string function, params object[] args)
        => string.Format(function, TranslateFunctionArguments(args));

}

using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.DataModels;

public sealed class Future<TResult> : IFuture
{
    private string Translated { get; }

    internal Future(TResult value)
        => Translated = $"{{{ObjectTranslator.Translate(value)}}}";

    public override string ToString()
        => $"{Translated}";
}

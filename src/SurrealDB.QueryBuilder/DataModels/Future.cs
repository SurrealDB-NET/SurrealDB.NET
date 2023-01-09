using SurrealDB.QueryBuilder.Functions;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.DataModels;

public sealed class Future<TResult> : IFuture
{
    internal TResult? Value { get; set; } = default;

    private string Translated { get; }

    internal Future(TResult value)
        => Translated = ObjectTranslator.Translate(value);

    internal Future(string script)
        => Translated = $"function(){{{script}}}";

    public override string ToString()
        => $"<future>{{{Translated}}}";
}

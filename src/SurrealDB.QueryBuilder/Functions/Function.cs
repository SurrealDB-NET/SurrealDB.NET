namespace SurrealDB.QueryBuilder.Functions;

public class Function
{
    private string Translated { get; }

    internal Function(string translatedFunction)
        => Translated = translatedFunction;

    public override string ToString()
        => Translated;
}

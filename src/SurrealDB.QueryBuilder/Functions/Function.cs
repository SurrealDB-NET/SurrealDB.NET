namespace SurrealDB.QueryBuilder.Functions;

public class Function
{
    internal Function(string translatedFunction)
        => Translated = translatedFunction;

    private string Translated { get; }

    public override string ToString()
        => Translated;
}

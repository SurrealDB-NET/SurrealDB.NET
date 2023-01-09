namespace SurrealDB.QueryBuilder.Attributes;

public class SurrealFunctionAttribute : Attribute
{
    public string Translated { get; }

    public SurrealFunctionAttribute(string translatedFunction)
        => Translated = translatedFunction;
}

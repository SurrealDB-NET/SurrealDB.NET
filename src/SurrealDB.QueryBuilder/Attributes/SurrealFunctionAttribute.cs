namespace SurrealDB.QueryBuilder.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class SurrealFunctionAttribute : Attribute
{
    public string Translated { get; }

    public SurrealFunctionAttribute(string translatedFunction)
        => Translated = translatedFunction;
}

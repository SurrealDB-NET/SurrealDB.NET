namespace SurrealDB.QueryBuilder.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class SurrealOperatorAttribute : Attribute
{
    public string Translated { get; }

    public SurrealOperatorAttribute(string translatedOperator)
        => Translated = translatedOperator;
}

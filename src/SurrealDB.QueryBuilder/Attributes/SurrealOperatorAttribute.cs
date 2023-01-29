namespace SurrealDB.QueryBuilder.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
internal sealed class SurrealOperatorAttribute : Attribute
{
    public string Operator { get; }

    public SurrealOperatorAttribute(string surrealOperator)
        => Operator = surrealOperator;
}

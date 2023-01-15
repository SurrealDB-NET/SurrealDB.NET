namespace SurrealDB.QueryBuilder.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class SurrealOperatorAttribute : Attribute
{
    public string Operator { get; }

    public SurrealOperatorAttribute(string surrealOperator)
        => Operator = surrealOperator;
}

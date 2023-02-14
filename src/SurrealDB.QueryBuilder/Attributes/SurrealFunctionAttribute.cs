namespace SurrealDB.QueryBuilder.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
internal sealed class SurrealFunctionAttribute : Attribute
{
	public string Function { get; }

	public SurrealFunctionAttribute(string surrealFunction)
	{
		Function = surrealFunction;
	}
}

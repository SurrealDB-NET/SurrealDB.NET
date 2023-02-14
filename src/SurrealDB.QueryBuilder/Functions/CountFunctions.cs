using System.Collections;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class CountFunctions
{
	[SurrealFunction("count")]
	public static ulong Count()
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("count")]
	public static ulong Count(object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("count")]
	public static ulong Count(IEnumerable values)
	{
		throw new IllegalSurrealFunctionCallException();
	}
}

namespace SurrealDB.QueryBuilder.Functions;

using System.Collections;
using Attributes;
using Exceptions;

public static class CountFunctions
{
    [SurrealFunction("count")]
    public static ulong Count()
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("count")]
    public static ulong Count(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("count")]
    public static ulong Count(IEnumerable values)
        => throw new IllegalSurrealFunctionCallException();
}

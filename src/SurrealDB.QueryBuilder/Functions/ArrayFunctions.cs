using System.Collections;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ArrayFunctions
{
    [SurrealFunction("array::combine({0}, {1})")]
    public static IEnumerable Combine(IEnumerable array1, IEnumerable array2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::concat({0},{1})")]
    public static IEnumerable Concat(IEnumerable array1, IEnumerable array2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::difference({0},{1})")]
    public static IEnumerable Difference(IEnumerable array1, IEnumerable array2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::distinct({0})")]
    public static IEnumerable Distinct(IEnumerable array)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::intersect({0},{1})")]
    public static IEnumerable Intersect(IEnumerable array1, IEnumerable array2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::len({0})")]
    public static long Len(IEnumerable array)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::sort({0})")]
    public static IEnumerable Sort(IEnumerable array)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::sort({0},{1})")]
    public static IEnumerable Sort(IEnumerable array, bool isAscending)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::sort({0},{1})")]
    public static IEnumerable Sort(IEnumerable array, SortOrder sortOrder)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::sort::asc({0})")]
    public static IEnumerable SortByAsc(IEnumerable array)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::sort::desc({0})]")]
    public static IEnumerable SortByDesc(IEnumerable array)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("array::union({0},{1})")]
    public static IEnumerable Union(IEnumerable array1, IEnumerable array2)
        => throw new IllegalSurrealFunctionCallException();
}

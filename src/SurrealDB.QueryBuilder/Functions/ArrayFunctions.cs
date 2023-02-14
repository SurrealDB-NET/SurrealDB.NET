using System.Collections;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ArrayFunctions
{
	[SurrealFunction("array::combine")]
	public static IEnumerable Combine(IEnumerable array1, IEnumerable array2)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::concat")]
	public static IEnumerable Concat(IEnumerable array1, IEnumerable array2)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::difference")]
	public static IEnumerable Difference(IEnumerable array1, IEnumerable array2)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::distinct")]
	public static IEnumerable Distinct(IEnumerable array)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::intersect")]
	public static IEnumerable Intersect(IEnumerable array1, IEnumerable array2)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::len")]
	public static long Len(IEnumerable array)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::sort")]
	public static IEnumerable Sort(IEnumerable array)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::sort")]
	public static IEnumerable Sort(IEnumerable array, bool isAscending)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::sort")]
	public static IEnumerable Sort(IEnumerable array, SortOrder sortOrder)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::sort::asc")]
	public static IEnumerable SortByAsc(IEnumerable array)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::sort::desc")]
	public static IEnumerable SortByDesc(IEnumerable array)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("array::union")]
	public static IEnumerable Union(IEnumerable array1, IEnumerable array2)
	{
		throw new IllegalSurrealFunctionCallException();
	}
}

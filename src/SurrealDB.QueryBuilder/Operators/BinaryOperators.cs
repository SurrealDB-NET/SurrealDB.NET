using System.Collections;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class BinaryOperators
{
	[SurrealOperator("?=")]
	public static bool Any(IEnumerable values, object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("*=")]
	public static bool All(IEnumerable values, object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("~")]
	public static bool FuzzyMatch(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("!~")]
	public static bool NotFuzzyMatch(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("?~")]
	public static bool AnyFuzzyMatch(IEnumerable values, object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("*~")]
	public static bool AllFuzzyMatch(IEnumerable values, object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("∋")]
	public static bool Contains(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("∌")]
	public static bool NotContains(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊇")]
	public static bool ContainsAll(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊃")]
	public static bool ContainsAny(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊅")]
	public static bool ContainsNone(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("∈")]
	public static bool Inside(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("∉")]
	public static bool NotInside(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊆")]
	public static bool AllInside(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊂")]
	public static bool AnyInside(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("⊄")]
	public static bool NoneInside(object? left, object? right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("OUTSIDE")]
	public static bool Outside(IGeometry left, IGeometry right)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealOperator("INTERSECTS")]
	public static bool Intersects(IGeometry left, IGeometry right)
	{
		throw new IllegalSurrealFunctionCallException();
	}
}

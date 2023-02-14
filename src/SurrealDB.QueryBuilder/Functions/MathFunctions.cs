using System.Numerics;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class MathFunctions
{
	[SurrealFunction("math::abs")]
	public static TNumber Abs<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::ceil")]
	public static TNumber Ceil<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::fixed")]
	public static TNumber Fixed<TNumber>(TNumber number, long precision)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::floor")]
	public static TNumber Floor<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::max")]
	public static TNumber Max<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::max")]
	public static TNumber Max<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::mean")]
	public static TNumber Mean<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::mean")]
	public static TNumber Mean<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::median")]
	public static TNumber Median<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::median")]
	public static TNumber Median<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::min")]
	public static TNumber Min<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::min")]
	public static TNumber Min<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::product")]
	public static TNumber Product<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::product")]
	public static TNumber Product<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::round")]
	public static TNumber Round<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::sqrt")]
	public static TNumber Sqrt<TNumber>(TNumber number)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::sum")]
	public static TNumber Sum<TNumber>(params TNumber[] numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("math::sum")]
	public static TNumber Sum<TNumber>(IEnumerable<TNumber> numbers)
		where TNumber : INumber<TNumber>
	{
		throw new IllegalSurrealFunctionCallException();
	}
}

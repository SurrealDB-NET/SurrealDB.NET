using System.Numerics;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

using System.Numerics;

public static class MathFunctions
{
    [SurrealFunction("math::abs({0})")]
    public static TNumber Abs<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::ceil({0})")]
    public static TNumber Ceil<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::fixed({0})")]
    public static TNumber Fixed<TNumber>(TNumber number, long precision) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::floor({0})")]
    public static TNumber Floor<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::max({0})")]
    public static TNumber Max<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::mean({0})")]
    public static TNumber Mean<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::median({0})")]
    public static TNumber Median<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::min({0})")]
    public static TNumber Min<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::product({0})")]
    public static TNumber Product<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::round({0})")]
    public static TNumber Round<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::sqrt({0})")]
    public static TNumber Sqrt<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("math::sum({0})")]
    public static TNumber Sum<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => throw new IllegalSurrealFunctionCallException();
}

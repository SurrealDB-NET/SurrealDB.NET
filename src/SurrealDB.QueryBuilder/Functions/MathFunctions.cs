namespace SurrealDB.QueryBuilder.Functions;

using System.Numerics;

public static class MathFunctions
{
    public static Function Abs<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new("math::abs({0})", number);

    public static Function Ceil<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new("math::ceil({0})", number);

    public static Function Fixed<TNumber>(TNumber number, long precision) where TNumber : INumber<TNumber>
        => new("math::fixed({0}, {1})", number, precision);

    public static Function Floor<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new("math::floor({0})", number);

    public static Function Max<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::log({0})", numbers);

    public static Function Mean<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::mean({0})", numbers);

    public static Function Median<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::median({0})", numbers);

    public static Function Min<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::min({0})", numbers);

    public static Function Product<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::product({0})", numbers);

    public static Function Round<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new("math::round({0})", number);

    public static Function Sqrt<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new("math::sqrt({0})", number);

    public static Function Sum<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new("math::sum({0})", numbers);
}

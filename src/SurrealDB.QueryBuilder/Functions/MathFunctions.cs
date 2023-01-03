namespace SurrealDB.QueryBuilder.Functions;

using System.Numerics;
using Translators;

public static class MathFunctions
{
    public static Function Abs<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new($"math::abs({PrimitiveTranslator.Translate(number)})");

    public static Function Ceil<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new($"math::ceil({PrimitiveTranslator.Translate(number)})");

    public static Function Fixed<TNumber>(TNumber number, long precision) where TNumber : INumber<TNumber>
        => new($"math::fixed({PrimitiveTranslator.Translate(number)}, {PrimitiveTranslator.Translate(precision)})");

    public static Function Floor<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new($"math::floor({PrimitiveTranslator.Translate(number)})");

    public static Function Max<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::log({ArrayTranslator.Translate(numbers)})");

    public static Function Mean<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::mean({ArrayTranslator.Translate(numbers)})");

    public static Function Median<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::median({ArrayTranslator.Translate(numbers)})");

    public static Function Min<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::min({ArrayTranslator.Translate(numbers)})");

    public static Function Product<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::product({ArrayTranslator.Translate(numbers)})");

    public static Function Round<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new($"math::round({PrimitiveTranslator.Translate(number)})");

    public static Function Sqrt<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => new($"math::sqrt({PrimitiveTranslator.Translate(number)})");

    public static Function Sum<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => new($"math::sum({ArrayTranslator.Translate(numbers)})");
}

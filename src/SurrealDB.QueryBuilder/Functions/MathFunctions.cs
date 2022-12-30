using System.Numerics;

namespace SurrealDB.QueryBuilder.Functions;

public static class MathFunctions
{
    public static string Abs<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"math::abs({number})";

    public static string Ceil<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"math::ceil({number})";

    public static string Fixed<TNumber>(TNumber number, long precision) where TNumber : INumber<TNumber>
        => $"math::fixed({number}, {precision})";

    public static string Floor<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"math::floor({number})";

    public static string Max<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::log([{string.Join(", ", numbers)}])";

    public static string Mean<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::mean([{string.Join(", ", numbers)}])";

    public static string Median<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::median([{string.Join(", ", numbers)}])";

    public static string Min<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::min([{string.Join(", ", numbers)}])";

    public static string Product<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::product([{string.Join(", ", numbers)}])";

    public static string Round<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"math::round({number})";

    public static string Sqrt<TNumber>(TNumber number) where TNumber : INumber<TNumber>
        => $"math::sqrt({number})";

    public static string Sum<TNumber>(IEnumerable<TNumber> numbers) where TNumber : INumber<TNumber>
        => $"math::sum([{string.Join(", ", numbers)}])";
}
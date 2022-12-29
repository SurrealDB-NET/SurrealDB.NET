using System.Numerics;

namespace SurrealDB.QueryBuilder.Functions;

public static class MathFunction<TNumber> where TNumber : INumber<TNumber>
{
    public static string Abs(TNumber number)
        => $"math::abs({number})";

    public static string Ceil(TNumber number)
        => $"math::ceil({number})";

    public static string Fixed(TNumber number, int precision)
        => $"math::fixed({number}, {precision})";

    public static string Floor(TNumber number)
        => $"math::floor({number})";

    public static string Max(IEnumerable<TNumber> numbers)
        => $"math::log([{string.Join(", ", numbers)}])";

    public static string Mean(IEnumerable<TNumber> numbers)
        => $"math::mean([{string.Join(", ", numbers)}])";

    public static string Median(IEnumerable<TNumber> numbers)
        => $"math::median([{string.Join(", ", numbers)}])";

    public static string Min(IEnumerable<TNumber> numbers)
        => $"math::min([{string.Join(", ", numbers)}])";

    public static string Product(IEnumerable<TNumber> numbers)
        => $"math::product([{string.Join(", ", numbers)}])";

    public static string Round(TNumber number)
        => $"math::round({number})";

    public static string Sqrt(TNumber number)
        => $"math::sqrt({number})";

    public static string Sum(IEnumerable<TNumber> numbers)
        => $"math::sum([{string.Join(", ", numbers)}])";
}
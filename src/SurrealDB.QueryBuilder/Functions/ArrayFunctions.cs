using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

public static class ArrayFunctions
{
    public static Function Combine(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::combine({EnumerableTranslator.Translate(array1)}, {EnumerableTranslator.Translate(array2)})");

    public static Function Concat(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::concat({EnumerableTranslator.Translate(array1)}, {EnumerableTranslator.Translate(array2)})");

    public static Function Difference(IEnumerable<object> array1, IEnumerable<object> array2)
        => new(
            $"array::difference({EnumerableTranslator.Translate(array1)}, {EnumerableTranslator.Translate(array2)})");

    public static Function Distinct(IEnumerable<object> array)
        => new($"array::distinct({EnumerableTranslator.Translate(array)})");

    public static Function Intersect(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::intersect({EnumerableTranslator.Translate(array1)}, {EnumerableTranslator.Translate(array2)})");

    public static Function Len(IEnumerable<object> array)
        => new($"array::len({EnumerableTranslator.Translate(array)})");

    public static Function Sort(IEnumerable<object> array)
        => new($"array::sort({EnumerableTranslator.Translate(array)})");

    public static Function Sort(IEnumerable<object> array, bool isAscending)
        => new(
            $"array::sort({EnumerableTranslator.Translate(array)}, {PrimitiveTranslator.Translate(isAscending.ToString()).ToLower()})");

    public static Function Sort(IEnumerable<object> array, SortOrder sortOrder)
        => new(
            $"array::sort({EnumerableTranslator.Translate(array)}, {PrimitiveTranslator.Translate(sortOrder.ToString()).ToLower()})");

    public static Function SortByAsc(IEnumerable<object> array)
        => new($"array::sort::asc({EnumerableTranslator.Translate(array)})");

    public static Function SortByDesc(IEnumerable<object> array)
        => new($"array::sort::desc({EnumerableTranslator.Translate(array)})");

    public static Function Union(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::union({EnumerableTranslator.Translate(array1)}, {EnumerableTranslator.Translate(array2)})");
}

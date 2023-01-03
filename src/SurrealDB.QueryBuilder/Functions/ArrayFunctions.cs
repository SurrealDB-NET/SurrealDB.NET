namespace SurrealDB.QueryBuilder.Functions;

using Enums;
using Translators;

public static class ArrayFunctions
{
    public static Function Combine(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::combine({ArrayTranslator.Translate(array1)}, {ArrayTranslator.Translate(array2)})");

    public static Function Concat(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::concat({ArrayTranslator.Translate(array1)}, {ArrayTranslator.Translate(array2)})");

    public static Function Difference(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::difference({ArrayTranslator.Translate(array1)}, {ArrayTranslator.Translate(array2)})");

    public static Function Distinct(IEnumerable<object> array)
        => new($"array::distinct({ArrayTranslator.Translate(array)})");

    public static Function Intersect(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::intersect({ArrayTranslator.Translate(array1)}, {ArrayTranslator.Translate(array2)})");

    public static Function Len(IEnumerable<object> array)
        => new($"array::len({ArrayTranslator.Translate(array)})");

    public static Function Sort(IEnumerable<object> array)
        => new($"array::sort({ArrayTranslator.Translate(array)})");

    public static Function Sort(IEnumerable<object> array, bool isAscending)
        => new($"array::sort({ArrayTranslator.Translate(array)}, {PrimitiveTranslator.Translate(isAscending.ToString()).ToLower()})");

    public static Function Sort(IEnumerable<object> array, SortOrder sortOrder)
        => new($"array::sort({ArrayTranslator.Translate(array)}, {PrimitiveTranslator.Translate(sortOrder.ToString()).ToLower()})");

    public static Function SortByAsc(IEnumerable<object> array)
        => new($"array::sort::asc({ArrayTranslator.Translate(array)})");

    public static Function SortByDesc(IEnumerable<object> array)
        => new($"array::sort::desc({ArrayTranslator.Translate(array)})");

    public static Function Union(IEnumerable<object> array1, IEnumerable<object> array2)
        => new($"array::union({ArrayTranslator.Translate(array1)}, {ArrayTranslator.Translate(array2)})");
}

namespace SurrealDB.QueryBuilder.Functions;

using Enums;

public static class ArrayFunctions
{
    public static Function Combine(IEnumerable<object> array1, IEnumerable<object> array2)
        => new("array::combine({0}, {1})", array1, array2);

    public static Function Concat(IEnumerable<object> array1, IEnumerable<object> array2)
        => new("array::concat({0}, {1})", array1, array2);

    public static Function Difference(IEnumerable<object> array1, IEnumerable<object> array2)
        => new("array::difference({0}, {1})", array1, array2);

    public static Function Distinct(IEnumerable<object> array)
        => new("array::distinct({0})", array);

    public static Function Intersect(IEnumerable<object> array1, IEnumerable<object> array2)
        => new("array::intersect({0}, {1})", array1, array2);

    public static Function Len(IEnumerable<object> array)
        => new("array::len({0})", array);

    public static Function Sort(IEnumerable<object> array)
        => new("array::sort({0})", array);

    public static Function Sort(IEnumerable<object> array, bool isAscending)
        => new("array::sort({0}, {1})", array, isAscending);

    public static Function Sort(IEnumerable<object> array, SortOrder sortOrder)
        => new("array::sort({0}, {1})", array, sortOrder.ToString().ToLower());

    public static Function SortByAsc(IEnumerable<object> array)
        => new("array::sort::asc({0})", array);

    public static Function SortByDesc(IEnumerable<object> array)
        => new("array::sort::desc({0})", array);

    public static Function Union(IEnumerable<object> array1, IEnumerable<object> array2)
        => new("array::union({0}, {1})", array1, array2);
}

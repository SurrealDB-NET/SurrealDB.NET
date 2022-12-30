using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Functions;

public static class ArrayFunctions
{
    public static string Combine(IEnumerable<object> array1, IEnumerable<object> array2)
        => $"array::combine([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Concat(IEnumerable<object> array1, IEnumerable<object> array2)
        => $"array::concat([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Difference(IEnumerable<object> array1, IEnumerable<object> array2)
        => $"array::difference([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Distinct(IEnumerable<object> array)
        => $"array::distinct([{string.Join(", ", array)}])";

    public static string Intersect(IEnumerable<object> array1, IEnumerable<object> array2)
        => $"array::intersect([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Len(IEnumerable<object> array)
        => $"array::len([{string.Join(", ", array)}])";

    public static string Sort(IEnumerable<object> array)
        => $"array::sort([{string.Join(", ", array)}])";

    public static string Sort(IEnumerable<object> array, bool isAscending)
        => $"array::sort([{string.Join(", ", array)}], {isAscending.ToString().ToLower()})";

    public static string Sort(IEnumerable<object> array, SortOrder sortOrder)
        => $"array::sort([{string.Join(", ", array)}], {sortOrder.ToString().ToLower()})";

    public static string SortByAsc(IEnumerable<object> array)
        => $"array::sort::asc([{string.Join(", ", array)}])";

    public static string SortByDesc(IEnumerable<object> array)
        => $"array::sort::desc([{string.Join(", ", array)}])";

    public static string Union(IEnumerable<object> array1, IEnumerable<object> array2)
        => $"array::union([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";
}

using SurrealDB.QueryBuilder.Enums;

namespace SurrealDB.QueryBuilder.Functions;

public static class ArrayFunction
{
    public static string Combine(ICollection<object> array1, ICollection<dynamic> array2)
        => $"array::combine([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Concat(ICollection<object> array1, ICollection<object> array2)
        => $"array::concat([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Difference(ICollection<object> array1, ICollection<object> array2)
        => $"array::difference([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Distinct(ICollection<object> array)
        => $"array::distinct([{string.Join(", ", array)}])";

    public static string Intersect(ICollection<object> array1, ICollection<object> array2)
        => $"array::intersect([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";

    public static string Len(ICollection<object> array)
        => $"array::len([{string.Join(", ", array)}])";

    public static string Sort(ICollection<object> array)
        => $"array::sort([{string.Join(", ", array)}])";

    public static string Sort(ICollection<object> array, bool isAscending)
        => $"array::sort([{string.Join(", ", array)}], {isAscending.ToString().ToLower()})";

    public static string Sort(ICollection<object> array, SortOrder sortOrder)
        => $"array::sort([{string.Join(", ", array)}], {sortOrder.ToString().ToLower()})";

    public static class SortDirection
    {
        public static string Asc(ICollection<object> array)
            => $"array::sort::asc([{string.Join(", ", array)}])";

        public static string Desc(ICollection<object> array)
            => $"array::sort::desc([{string.Join(", ", array)}])";
    }

    public static string Union(ICollection<object> array1, ICollection<object> array2)
        => $"array::union([{string.Join(", ", array1)}], [{string.Join(", ", array2)}])";
}
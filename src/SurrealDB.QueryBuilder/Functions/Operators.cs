using System.Collections;
using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder;

public static class Operators
{
    [SurrealFunction("({0}?={1})")]
    public static bool Any(IEnumerable values, object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}*={1})")]
    public static bool All(IEnumerable<object?> values, object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}~{1})")]
    public static bool FuzzyMatch(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}!~{1})")]
    public static bool NotFuzzyMatch(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}?~{1})")]
    public static bool AnyFuzzyMatch(IEnumerable<object?> values, object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}*~{1})")]
    public static bool AllFuzzyMatch(IEnumerable<object?> values, object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}∋{1})")]
    public static bool Contains(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}∌{1})")]
    public static bool NotContains(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊇{1})")]
    public static bool ContainsAll(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊃{1})")]
    public static bool ContainsAny(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊅{1})")]
    public static bool ContainsNone(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}∈{1})")]
    public static bool Inside(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}∉{1})")]
    public static bool NotInside(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊆{1})")]
    public static bool AllInside(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊂{1})")]
    public static bool AnyInside(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}⊄{1})")]
    public static bool NoneInside(object? left, object? right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}OUTSIDE{1})")]
    public static bool Outside(IGeometry left, IGeometry right)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("({0}INTERSECTS{1})")]
    public static bool Intersects(IGeometry left, IGeometry right)
        => throw new IllegalSurrealFunctionCallException();
}

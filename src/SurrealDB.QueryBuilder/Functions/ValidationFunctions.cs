using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ValidationFunctions
{
    [SurrealFunction("is::alpha({0})")]
    public static bool IsAlpha(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::alphanum({0})")]
    public static bool IsAlphaNum(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::ascii({0})")]
    public static bool IsAscii(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::domain({0})")]
    public static bool IsDomain(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::email({0})")]
    public static bool IsEmail(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::hexadecimal({0})")]
    public static bool IsHexadecimal(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::latitude({0})")]
    public static bool IsLatitude(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::longitude({0})")]
    public static bool IsLongitude(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::numeric({0})")]
    public static bool IsNumeric(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::semver({0})")]
    public static bool IsSemver(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::url({0})")]
    public static bool IsUuid(string value)
        => throw new IllegalSurrealFunctionCallException();
}

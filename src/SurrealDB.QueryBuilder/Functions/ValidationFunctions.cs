using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ValidationFunctions
{
    [SurrealFunction("is::alpha")]
    public static bool IsAlpha(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::alphanum")]
    public static bool IsAlphaNum(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::ascii")]
    public static bool IsAscii(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::domain")]
    public static bool IsDomain(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::email")]
    public static bool IsEmail(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::hexadecimal")]
    public static bool IsHexadecimal(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::latitude")]
    public static bool IsLatitude(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::longitude")]
    public static bool IsLongitude(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::numeric")]
    public static bool IsNumeric(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::semver")]
    public static bool IsSemver(string value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("is::url")]
    public static bool IsUuid(string value)
        => throw new IllegalSurrealFunctionCallException();
}

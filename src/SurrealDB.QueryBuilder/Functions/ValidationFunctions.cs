namespace SurrealDB.QueryBuilder.Functions;

public static class ValidationFunctions
{
    public static Function IsAlpha(string value)
        => new("is::alpha({0})", value);

    public static Function IsAlphaNum(string value)
        => new("is::alphanum({0})", value);

    public static Function IsAscii(string value)
        => new("is::ascii({0})", value);

    public static Function IsDomain(string value)
        => new("is::domain({0})", value);

    public static Function IsEmail(string value)
        => new("is::email({0})", value);

    public static Function IsHexadecimal(string value)
        => new("is::hexadecimal({0})", value);

    public static Function IsLatitude(string value)
        => new("is::latitude({0})", value);

    public static Function IsLongitude(string value)
        => new("is::longitude({0})", value);

    public static Function IsNumeric(string value)
        => new("is::numeric({0})", value);

    public static Function IsSemver(string value)
        => new("is::semver({0})", value);

    public static Function IsUuid(string value)
        => new("is::uuid({0})", value);
}

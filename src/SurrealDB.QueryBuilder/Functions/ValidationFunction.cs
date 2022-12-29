namespace SurrealDB.QueryBuilder.Functions;

public static class ValidationFunction
{
    public static string IsAlphanum(object value)
        => $"is::alphanum({value})";

    public static string IsAlpha(object value)
        => $"is::alpha({value})";

    public static string IsAscii(object value)
        => $"is::ascii({value})";

    public static string IsDomain(object value)
        => $"is::domain({value})";

    public static string IsEmail(object value)
        => $"is::email({value})";

    public static string IsHexadecimal(object value)
        => $"is::hexadecimal({value})";

    public static string IsLatitude(object value)
        => $"is::latitude({value})";

    public static string IsLongitude(object value)
        => $"is::longitude({value})";

    public static string IsNumeric(object value)
        => $"is::numeric({value})";

    public static string IsSemver(object value)
        => $"is::semver({value})";

    public static string IsUuid(object value)
        => $"is::uuid({value})";
}
namespace SurrealDB.QueryBuilder.Functions;

public static class ValidationFunction
{
    public static string IsAlphanum(string value)
        => $"is::alphanum('{value}')";

    public static string IsAlpha(string value)
        => $"is::alpha('{value}')";

    public static string IsAscii(string value)
        => $"is::ascii('{value}')";

    public static string IsDomain(string value)
        => $"is::domain('{value}')";

    public static string IsEmail(string value)
        => $"is::email('{value}')";

    public static string IsHexadecimal(string value)
        => $"is::hexadecimal('{value}')";

    public static string IsLatitude(string value)
        => $"is::latitude('{value}')";

    public static string IsLongitude(string value)
        => $"is::longitude('{value}')";

    public static string IsNumeric(string value)
        => $"is::numeric('{value}')";

    public static string IsSemver(string value)
        => $"is::semver('{value}')";

    public static string IsUuid(string value)
        => $"is::uuid('{value}')";
}
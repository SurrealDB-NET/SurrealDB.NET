namespace SurrealDB.QueryBuilder.Functions;

using Translators;

public static class ValidationFunctions
{
    public static Function IsAlpha(string value)
        => new($"is::alpha({PrimitiveTranslator.Translate(value)})");
    
    public static Function IsAlphaNum(string value)
        => new($"is::alphanum({PrimitiveTranslator.Translate(value)})");

    public static Function IsAscii(string value)
        => new($"is::ascii({PrimitiveTranslator.Translate(value)})");

    public static Function IsDomain(string value)
        => new($"is::domain({PrimitiveTranslator.Translate(value)})");

    public static Function IsEmail(string value)
        => new($"is::email({PrimitiveTranslator.Translate(value)})");

    public static Function IsHexadecimal(string value)
        => new($"is::hexadecimal({PrimitiveTranslator.Translate(value)})");

    public static Function IsLatitude(string value)
        => new($"is::latitude({PrimitiveTranslator.Translate(value)})");

    public static Function IsLongitude(string value)
        => new($"is::longitude({PrimitiveTranslator.Translate(value)})");

    public static Function IsNumeric(string value)
        => new($"is::numeric({PrimitiveTranslator.Translate(value)})");

    public static Function IsSemver(string value)
        => new($"is::semver({PrimitiveTranslator.Translate(value)})");

    public static Function IsUuid(string value)
        => new($"is::uuid({PrimitiveTranslator.Translate(value)})");
}
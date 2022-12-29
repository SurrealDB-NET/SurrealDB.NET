using System.Numerics;

namespace SurrealDB.QueryBuilder.Functions;

public static class RandomFunction
{
    public static string Rand()
        => "rand()";

    public static string Bool()
        => "rand::bool()";

    public static string Enum(params object[] values)
        => $"rand::enum([{string.Join(", ", values)}])";

    public static string Float()
        => "rand::float()";

    public static string Float<TMin, TMax>(TMin min, TMax max)
        where TMin : INumber<TMin>
        where TMax : INumber<TMax>
        => $"rand::float({min}, {max})";

    public static string Guid()
        => "rand::guid()";

    public static string Guid<TLength>(TLength length)
        where TLength : INumber<TLength>
        => $"rand::guid({length})";

    public static string Int()
        => "rand::int()";

    public static string Int<TMin, TMax>(TMin min, TMax max)
        where TMin : INumber<TMin>
        where TMax : INumber<TMax>
        => $"rand::int({min}, {max})";

    public static string String()
        => "rand::string()";

    public static string String<TLength>(TLength length)
        where TLength : INumber<TLength>
        => $"rand::string({length})";

    public static string String<TMinLength, TMaxLength>(TMinLength minLength, TMaxLength maxLength)
        where TMinLength : INumber<TMinLength>
        where TMaxLength : INumber<TMaxLength>
        => $"rand::string({minLength}, {maxLength})";

    public static string Time()
        => "rand::time()";

    public static string Time<TMinUnixTime, TMaxUnixTime>(TMinUnixTime minUnixTime, TMaxUnixTime maxUnixTime)
        where TMinUnixTime : INumber<TMinUnixTime>
        where TMaxUnixTime : INumber<TMaxUnixTime>
        => $"rand::time({minUnixTime}, {maxUnixTime})";

    public static string Uuid()
        => "rand::uuid()";
}
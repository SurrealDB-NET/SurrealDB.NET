namespace SurrealDB.QueryBuilder.Functions;

using System.Numerics;

public static class RandomFunctions
{
    public static Function Rand()
        => new("rand()");

    public static Function Bool()
        => new("rand::bool()");

    public static Function Enum(params object[] values)
        => new("rand::enum({0})", values);

    public static Function Float()
        => new("rand::float()");

    public static Function Float<TMin, TMax>(TMin min, TMax max)
        where TMin : INumber<TMin>
        where TMax : INumber<TMax>
        => new("rand::float({0}, {1})", min, max);

    public static Function Guid()
        => new("rand::guid()");

    public static Function Guid<TLength>(TLength length)
        where TLength : INumber<TLength>
        => new("rand::guid({0})", length);

    public static Function Int()
        => new("rand::int()");

    public static Function Int<TMin, TMax>(TMin min, TMax max)
        where TMin : INumber<TMin>
        where TMax : INumber<TMax>
        => new("rand::int({0}, {1})", min, max);

    public static Function String()
        => new("rand::string()");

    public static Function String<TLength>(TLength length)
        where TLength : INumber<TLength>
        => new("rand::string({0})", length);

    public static Function String<TMinLength, TMaxLength>(TMinLength minLength, TMaxLength maxLength)
        where TMinLength : INumber<TMinLength>
        where TMaxLength : INumber<TMaxLength>
        => new("rand::string({0}, {1})", minLength, maxLength);

    public static Function Time()
        => new("rand::time()");

    public static Function Time<TMinUnixTime, TMaxUnixTime>(TMinUnixTime minUnixTime, TMaxUnixTime maxUnixTime)
        where TMinUnixTime : INumber<TMinUnixTime>
        where TMaxUnixTime : INumber<TMaxUnixTime>
        => new("rand::time({0}, {1})", minUnixTime, maxUnixTime);

    public static Function Uuid()
        => new("rand::uuid()");
}

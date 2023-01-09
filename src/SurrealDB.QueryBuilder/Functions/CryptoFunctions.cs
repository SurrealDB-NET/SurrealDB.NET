using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunctions
{
    [SurrealFunction("crypto::md5({0})")]
    public static string Md5(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("crypto::sha1({0})")]
    public static string Sha1(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("crypto::sha256({0})")]
    public static string Sha256(object? value)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("crypto::sha512({0})")]
    public static string Sha512(object? value)
        => throw new IllegalSurrealFunctionCallException();

    public static class Argon2
    {
        [SurrealFunction("crypto::argon2::compare({0},{1})")]
        public static bool Compare(object? hash, object? unhashed)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("crypto::argon2::generate({0})")]
        public static string Generate(object? value)
            => throw new IllegalSurrealFunctionCallException();
    }

    public static class Pbkdf2
    {
        [SurrealFunction("crypto::pbkdf2::compare({0},{1})")]
        public static bool Compare(object? hash, object? unhashed)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("crypto::pbkdf2::generate({0})")]
        public static string Generate(object? value)
            => throw new IllegalSurrealFunctionCallException();
    }

    public static class Scrypt
    {
        [SurrealFunction("crypto::scrypt::compare({0},{1})")]
        public static bool Compare(object? hash, object? unhashed)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("crypto::scrypt::generate({0})")]
        public static string Generate(object? value)
            => throw new IllegalSurrealFunctionCallException();
    }
}

using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunctions
{
    public static Function Md5(string value)
        => new($"crypto::md5({PrimitiveTranslator.Translate(value)})");

    public static Function Sha1(string value)
        => new($"crypto::sha1({PrimitiveTranslator.Translate(value)})");

    public static Function Sha256(string value)
        => new($"crypto::sha256({PrimitiveTranslator.Translate(value)})");

    public static Function Sha512(string value)
        => new($"crypto::sha512({PrimitiveTranslator.Translate(value)})");

    public static class Argon2
    {
        public static Function Compare(string hash, string plainText)
            => new(
                $"crypto::argon2::compare({PrimitiveTranslator.Translate(hash)}, {PrimitiveTranslator.Translate(plainText)})");

        public static Function Generate(string value)
            => new($"crypto::argon2::generate({PrimitiveTranslator.Translate(value)})");
    }

    public static class Pbkdf2
    {
        public static Function Compare(string hash, string plainText)
            => new(
                $"crypto::pbkdf2::compare({PrimitiveTranslator.Translate(hash)}, {PrimitiveTranslator.Translate(plainText)})");

        public static Function Generate(string value)
            => new($"crypto::pbkdf2::generate({PrimitiveTranslator.Translate(value)})");
    }

    public static class Scrypt
    {
        public static Function Compare(string hash, string plainText)
            => new(
                $"crypto::scrypt::compare({PrimitiveTranslator.Translate(hash)}, {PrimitiveTranslator.Translate(plainText)})");

        public static Function Generate(string value)
            => new($"crypto::scrypt::generate({PrimitiveTranslator.Translate(value)})");
    }
}

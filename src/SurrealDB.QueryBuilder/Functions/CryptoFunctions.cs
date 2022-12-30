namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunctions
{
    public static string Md5(string value)
        => $"crypto::md5('{value}')";

    public static string Sha1(string value)
        => $"crypto::sha1('{value}')";

    public static string Sha256(string value)
        => $"crypto::sha256('{value}')";

    public static string Sha512(string value)
        => $"crypto::sha512('{value}')";

    public static class Argon2
    {
        public static string Compare(string hash, string plainText)
            => $"crypto::argon2::compare('{hash}', '{plainText}')";

        public static string Generate(string value)
            => $"crypto::argon2::generate('{value}')";
    }

    public static class Pbkdf2
    {
        public static string Compare(string hash, string plainText)
            => $"crypto::pbkdf2::compare('{hash}', '{plainText}')";

        public static string Generate(string value)
            => $"crypto::pbkdf2::generate('{value}')";
    }

    public static class Scrypt
    {
        public static string Compare(string hash, string plainText)
            => $"crypto::scrypt::compare('{hash}', '{plainText}')";

        public static string Generate(string value)
            => $"crypto::scrypt::generate('{value}')";
    }
}

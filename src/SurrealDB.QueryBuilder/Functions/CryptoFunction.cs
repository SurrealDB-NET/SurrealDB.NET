namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunction
{
    public static string Md5(object value) => $"crypto::md5({value})";
    public static string Sha1(object value) => $"crypto::sha1({value})";
    public static string Sha256(object value) => $"crypto::sha256({value})";
    public static string Sha512(object value) => $"crypto::sha512({value})";

    public static class Argon2
    {
        public static string Compare(object hash, object plainText) => $"crypto::argon2::compare({hash}, {plainText})";
        public static string Generate(object value) => $"crypto::argon2::generate({value})";
    }

    public static class Pbkdf2
    {
        public static string Compare(object hash, object plainText) => $"crypto::pbkdf2::compare({hash}, {plainText})";
        public static string Generate(object value) => $"crypto::pbkdf2::generate({value})";
    }

    public static class Scrypt
    {
        public static string Compare(object hash, object plainText) => $"crypto::scrypt::compare({hash}, {plainText})";
        public static string Generate(object value) => $"crypto::scrypt::generate({value})";
    }
}
namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunctions
{
    public static Function Md5(object value)
        => new("crypto::md5({0})", value);

    public static Function Sha1(object value)
        => new("crypto::sha1({0})", value);

    public static Function Sha256(object value)
        => new("crypto::sha256({0})", value);

    public static Function Sha512(object value)
        => new("crypto::sha512({0})", value);

    public static class Argon2
    {
        public static Function Compare(object hash, object plainText)
            => new("crypto::argon2::compare({0}, {1})", hash, plainText);

        public static Function Generate(object value)
            => new("crypto::argon2::generate({0})", value);
    }

    public static class Pbkdf2
    {
        public static Function Compare(object hash, object plainText)
            => new("crypto::pbkdf2::compare({0}, {1})", hash, plainText);

        public static Function Generate(object value)
            => new("crypto::pbkdf2::generate({0})", value);
    }

    public static class Scrypt
    {
        public static Function Compare(object hash, object plainText)
            => new("crypto::scrypt::compare({0}, {1})", hash, plainText);

        public static Function Generate(object value)
            => new("crypto::scrypt::generate({0})", value);
    }
}

using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class CryptoFunctions
{
	[SurrealFunction("crypto::md5")]
	public static string Md5(object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("crypto::sha1")]
	public static string Sha1(object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("crypto::sha256")]
	public static string Sha256(object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("crypto::sha512")]
	public static string Sha512(object? value)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	public static class Argon2
	{
		[SurrealFunction("crypto::argon2::compare")]
		public static bool Compare(object? hash, object? unhashed)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("crypto::argon2::generate")]
		public static string Generate(object? value)
		{
			throw new IllegalSurrealFunctionCallException();
		}
	}

	public static class Pbkdf2
	{
		[SurrealFunction("crypto::pbkdf2::compare")]
		public static bool Compare(object? hash, object? unhashed)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("crypto::pbkdf2::generate")]
		public static string Generate(object? value)
		{
			throw new IllegalSurrealFunctionCallException();
		}
	}

	public static class Scrypt
	{
		[SurrealFunction("crypto::scrypt::compare")]
		public static bool Compare(object? hash, object? unhashed)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("crypto::scrypt::generate")]
		public static string Generate(object? value)
		{
			throw new IllegalSurrealFunctionCallException();
		}
	}
}

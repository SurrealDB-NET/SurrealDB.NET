using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunctions
{
	public static class Email
	{
		[SurrealFunction("parse::email::domain")]
		public static string? Domain(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("parse::email::local")]
		public static string? User(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}
	}

	public static class Url
	{
		[SurrealFunction("parse::url::domain")]
		public static string? Domain(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("parse::url::fragment")]
		public static string? Fragment(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("parse::url::host")]
		public static string? Host(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("parse::url::path")]
		public static string? Path(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}

		[SurrealFunction("parse::url::port")]
		public static string? Port(string value)
		{
			throw new IllegalSurrealFunctionCallException();
		}
	}
}

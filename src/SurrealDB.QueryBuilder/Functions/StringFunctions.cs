using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class StringFunctions
{
	[SurrealFunction("string::length")]
	public static ulong Length(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::startsWith")]
	public static bool StartsWith(string value, string prefix)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::endsWith")]
	public static bool EndsWith(string value, string suffix)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::lowercase")]
	public static string Lowercase(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::uppercase")]
	public static string Uppercase(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::repeat")]
	public static string Repeat(string value, ulong count)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::replace")]
	public static string Replace(string value, string search, string replace)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::reverse")]
	public static string Reverse(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::slice")]
	public static string Slice(string value, long start, long end)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::slug")]
	public static string Slug(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::trim")]
	public static string Trim(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::concat")]
	public static string Concat(params string[] values)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::join")]
	public static string Join(string delimiter, params string[] values)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::words")]
	public static IEnumerable<string> Words(string value)
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("string::split")]
	public static IEnumerable<string> Split(string value, string delimiter)
		=> throw new IllegalSurrealFunctionCallException();
}

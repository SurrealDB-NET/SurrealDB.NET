using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class HttpFunctions
{
	[SurrealFunction("http::head")]
	public static object Head(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::head")]
	public static object Head(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::get")]
	public static object Get(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::get")]
	public static object Get(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::put")]
	public static object Put(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::put")]
	public static object Put(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::post")]
	public static object Post(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::post")]
	public static object Post(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::patch")]
	public static object Patch(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::patch")]
	public static object Patch(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::delete")]
	public static object Delete(string url)
	{
		throw new IllegalSurrealFunctionCallException();
	}

	[SurrealFunction("http::delete")]
	public static object Delete(string url, object headers)
	{
		throw new IllegalSurrealFunctionCallException();
	}
}

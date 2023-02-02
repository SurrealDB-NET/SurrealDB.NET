using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class SessionFunctions
{
	[SurrealFunction("session::db")]
	public static string Db()
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("session::id")]
	public static string Id()
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("session::ip")]
	public static string Ip()
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("session::ns")]
	public static string Ns()
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("session::origin")]
	public static string Origin()
		=> throw new IllegalSurrealFunctionCallException();

	[SurrealFunction("session::sc")]
	public static string Sc()
		=> throw new IllegalSurrealFunctionCallException();
}

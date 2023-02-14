namespace SurrealDB.Client.Exceptions;

public class SurrealQueryException : SurrealException
{
	internal SurrealQueryException(string message)
		: base(message) { }
}

namespace SurrealDB.Client.Exceptions;

public class SurrealException : Exception
{
    internal SurrealException(string message) : base(message) { }
}

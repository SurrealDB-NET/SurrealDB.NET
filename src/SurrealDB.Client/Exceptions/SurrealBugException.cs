namespace SurrealDB.Client.Exceptions;

public class SurrealBugException : SurrealException
{
    internal SurrealBugException(string message) :
        base($"{message}\nThis should not have happened, please report this as a bug with reproduction steps.") { }
}

namespace SurrealDB.QueryBuilder.Exceptions;

public class IllegalSurrealFunctionCallException : Exception
{
    public IllegalSurrealFunctionCallException()
        : base("Illegal Surreal function call outside of a query.") { }
}

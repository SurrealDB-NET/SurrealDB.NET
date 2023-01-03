namespace SurrealDB.QueryBuilder.Functions;

public static class SessionFunctions
{
    public static Function Db()
        => new("session::db()");

    public static Function Id()
        => new("session::id()");

    public static Function Ip()
        => new("session::ip()");

    public static Function Ns()
        => new("session::ns()");

    public static Function Origin()
        => new("session::origin()");

    public static Function Sc()
        => new("session::sc()");
}
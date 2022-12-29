namespace SurrealDB.QueryBuilder.Functions;

public sealed class SessionFunction
{
    public static string DB()
        => "session::db()";

    public static string ID()
        => "session::id()";

    public static string IP()
        => "session::ip()";

    public static string NS()
        => "session::ns()";

    public static string Origin()
        => "session::origin()";

    public static string SC()
        => "session::sc()";
}
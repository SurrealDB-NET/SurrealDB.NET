namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunction
{
    public static class Email
    {
        public static string Domain(object value)
            => $"parse::email::domain('{value}')";

        public static string User(object value)
            => $"parse::email::user({value})";
    }

    public static class Url
    {
        public static string Domain(object value)
            => $"parse::url::domain({value})";

        public static string Fragment(object value)
            => $"parse::url::fragment({value})";

        public static string Host(object value)
            => $"parse::url::host({value})";

        public static string Path(object value)
            => $"parse::url::path({value})";

        public static string Port(object value)
            => $"parse::url::port({value})";
    }
}
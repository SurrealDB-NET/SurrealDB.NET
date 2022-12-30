namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunctions
{
    public static class Email
    {
        public static string Domain(string value)
            => $"parse::email::domain('{value}')";

        public static string User(string value)
            => $"parse::email::user('{value}')";
    }

    public static class Url
    {
        public static string Domain(string value)
            => $"parse::url::domain('{value}')";

        public static string Fragment(string value)
            => $"parse::url::fragment('{value}')";

        public static string Host(string value)
            => $"parse::url::host('{value}')";

        public static string Path(string value)
            => $"parse::url::path('{value}')";

        public static string Port(string value)
            => $"parse::url::port('{value}')";
    }
}
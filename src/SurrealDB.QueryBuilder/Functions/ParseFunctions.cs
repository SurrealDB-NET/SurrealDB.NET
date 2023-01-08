namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunctions
{
    public static class Email
    {
        public static Function Domain(string value)
            => new("parse::email::domain({0})", value);

        public static Function User(string value)
            => new("parse::email::user({0})", value);
    }

    public static class Url
    {
        public static Function Domain(string value)
            => new("parse::url::domain({0})", value);

        public static Function Fragment(string value)
            => new("parse::url::fragment({0})", value);

        public static Function Host(string value)
            => new("parse::url::host({0})", value);

        public static Function Path(string value)
            => new("parse::url::path({0})", value);

        public static Function Port(string value)
            => new("parse::url::port({0})", value);
    }
}

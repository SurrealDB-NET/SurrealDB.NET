using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunctions
{
    public static class Email
    {
        [SurrealFunction("parse::email::domain({0})")]
        public static string? Domain(string value)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("parse::email::local({0})")]
        public static string? User(string value)
            => throw new IllegalSurrealFunctionCallException();
    }

    public static class Url
    {
        [SurrealFunction("parse::url::domain({0})")]
        public static string? Domain(string value)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("parse::url::fragment({0})")]
        public static string? Fragment(string value)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("parse::url::host({0})")]
        public static string? Host(string value)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("parse::url::path({0})")]
        public static string? Path(string value)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("parse::url::port({0})")]
        public static string? Port(string value)
            => throw new IllegalSurrealFunctionCallException();
    }
}

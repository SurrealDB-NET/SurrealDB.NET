using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

public static class ParseFunctions
{
    public static class Email
    {
        public static Function Domain(string value)
            => new($"parse::email::domain({PrimitiveTranslator.Translate(value)})");

        public static Function User(string value)
            => new($"parse::email::user({PrimitiveTranslator.Translate(value)})");
    }

    public static class Url
    {
        public static Function Domain(string value)
            => new($"parse::url::domain({PrimitiveTranslator.Translate(value)})");

        public static Function Fragment(string value)
            => new($"parse::url::fragment({PrimitiveTranslator.Translate(value)})");

        public static Function Host(string value)
            => new($"parse::url::host({PrimitiveTranslator.Translate(value)})");

        public static Function Path(string value)
            => new($"parse::url::path({PrimitiveTranslator.Translate(value)})");

        public static Function Port(string value)
            => new($"parse::url::port({PrimitiveTranslator.Translate(value)})");
    }
}

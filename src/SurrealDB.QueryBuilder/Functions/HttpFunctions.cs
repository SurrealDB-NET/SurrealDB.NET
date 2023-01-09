using SurrealDB.QueryBuilder.Exceptions;
using SurrealDB.QueryBuilder.Translators;

namespace SurrealDB.QueryBuilder.Functions;

public static class HttpFunctions
{
    public static object? Head(string url)
        => throw new IllegalSurrealFunctionCallException();

    // public static Function<object?> Head(string url, object headers)
    //     => new($"http::head({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");

    // public static Function Get(string url)
    //     => new($"http::get({PrimitiveTranslator.Translate(url)})");

    // public static Function Get(string url, object headers)
    //     => new($"http::get({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");

    // public static Function Put(string url)
    //     => new($"http::put({PrimitiveTranslator.Translate(url)})");

    // public static Function Put(string url, object headers)
    //     => new($"http::put({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");

    // public static Function Post(string url)
    //     => new($"http::post({PrimitiveTranslator.Translate(url)})");

    // public static Function Post(string url, object headers)
    //     => new($"http::post({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");

    // public static Function Patch(string url)
    //     => new($"http::patch({PrimitiveTranslator.Translate(url)})");

    // public static Function Patch(string url, object headers)
    //     => new($"http::patch({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");

    // public static Function Delete(string url)
    //     => new($"http::delete({PrimitiveTranslator.Translate(url)})");

    // public static Function Delete(string url, object headers)
    //     => new($"http::delete({PrimitiveTranslator.Translate(url)}, {ObjectTranslator.Translate(headers)})");
}

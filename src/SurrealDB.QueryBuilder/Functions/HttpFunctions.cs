namespace SurrealDB.QueryBuilder.Functions;

public static class HttpFunctions
{
    public static Function Head(string url)
        => new("http::head({0})", url);

    public static Function Head(string url, object headers)
        => new("http::head({0}, {1})", url, headers);

    public static Function Get(string url)
        => new("http::get({0})", url);

    public static Function Get(string url, object headers)
        => new("http::get({0}, {1})", url, headers);

    public static Function Put(string url)
        => new("http::put({0})", url);

    public static Function Put(string url, object headers)
        => new("http::put({0}, {1})", url, headers);

    public static Function Post(string url)
        => new("http::post({0})", url);

    public static Function Post(string url, object headers)
        => new("http::post({0}, {1})", url, headers);

    public static Function Patch(string url)
        => new("http::patch({0})", url);

    public static Function Patch(string url, object headers)
        => new("http::patch({0}, {1})", url, headers);

    public static Function Delete(string url)
        => new("http::delete({0})", url);

    public static Function Delete(string url, object headers)
        => new("http::delete({0}, {1})", url, headers);
}

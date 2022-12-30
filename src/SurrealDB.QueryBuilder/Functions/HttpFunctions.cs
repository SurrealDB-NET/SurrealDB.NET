namespace SurrealDB.QueryBuilder.Functions;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class HttpFunctions
{
    public static string Head(string url)
        => $"http::head('{url}')";

    public static string Head(string url, object headers)
        => $"http::head('{url}', {SerializeHeaders(headers)})";

    public static string Get(string url)
        => $"http::get('{url}')";

    public static string Get(string url, object headers)
        => $"http::get('{url}', {SerializeHeaders(headers)})";

    public static string Put(string url)
        => $"http::put('{url}')";

    public static string Put(string url, object headers)
        => $"http::put('{url}', {SerializeHeaders(headers)})";

    public static string Post(string url)
        => $"http::post('{url}')";

    public static string Post(string url, object headers)
        => $"http::post('{url}', {SerializeHeaders(headers)})";

    public static string Patch(string url)
        => $"http::patch('{url}')";

    public static string Patch(string url, object headers)
        => $"http::patch('{url}', {SerializeHeaders(headers)})";

    public static string Delete(string url)
        => $"http::delete('{url}')";

    public static string Delete(string url, object headers)
        => $"http::delete('{url}', {SerializeHeaders(headers)})";

    private static string SerializeHeaders(object headers)
    {
        return JsonSerializer.Serialize(headers, new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.WriteAsString
        });
    }
}

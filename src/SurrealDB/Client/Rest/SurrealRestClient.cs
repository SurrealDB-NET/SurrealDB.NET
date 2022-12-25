namespace SurrealDB.Client.Rest;

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Responses;

public class SurrealRestClient : ISurrealClient
{
    private readonly HttpClient _httpClient;

    public SurrealRestClient(HttpClient httpClient, Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        _httpClient = ConfigureHttpClient(httpClient, optionsBuilder);
    }

    public async Task<TResult> ExecuteSqlAsync<TResult>(string sql, CancellationToken cancellationToken = default) where TResult : class
    {
        var payload = new StringContent(sql);

        var response = await _httpClient.PostAsync("sql", payload, cancellationToken);

        var results = await ParseResponseAsync<ExecuteSqlResponse<TResult>[]>(response, cancellationToken);

        return results.Select(result => result.Result).Single();
    }

    private static ISurrealClientOptions BuildOptions(Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        var builder = new SurrealClientOptionsBuilder();

        optionsBuilder(builder);

        return builder.Build();
    }

    private static HttpClient ConfigureHttpClient(HttpClient httpClient, Action<SurrealClientOptionsBuilder> optionsBuilder)
    {
        var options = BuildOptions(optionsBuilder);

        httpClient.BaseAddress = new Uri(options.BaseAddress);

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        httpClient.DefaultRequestHeaders.Authorization = CreateAuthorizationHeader(options.Username, options.Password);

        httpClient.DefaultRequestHeaders.Add("DB", options.Database);
        httpClient.DefaultRequestHeaders.Add("NS", options.Namespace);

        return httpClient;
    }

    private static AuthenticationHeaderValue CreateAuthorizationHeader(string username, string password)
    {
        var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
        var base64 = Convert.ToBase64String(bytes);

        return new AuthenticationHeaderValue("Basic", base64);
    }

    private static async Task<TResult> DeserializeContentAsync<TResult>(HttpContent content, CancellationToken cancellationToken = default) where TResult : class
    {
        var data = await content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);

        if (data is null)
        {
            throw new Exception("Failed to deserialize response");
        }

        return data;
    }

    private static async Task<TResult> ParseResponseAsync<TResult>(HttpResponseMessage response, CancellationToken cancellationToken = default) where TResult : class
    {
        if (response.IsSuccessStatusCode)
        {
            return await DeserializeContentAsync<TResult>(response.Content, cancellationToken);
        }

        var error = await DeserializeContentAsync<ErrorResponse>(response.Content, cancellationToken);

        throw new Exception($"({error.Code}) {error.Information}. {error.Description}");
    }
}

using System.Net.Http.Headers;
using System.Text;
using SurrealDB.Client.Enums;
using SurrealDB.Client.Exceptions;
using SurrealDB.Client.Responses;

namespace SurrealDB.Client.Rest;

public class SurrealRestClient : ISurrealRestClient
{
	private readonly HttpClient _httpClient;

	private readonly SurrealRestClientOptions _options;

	public SurrealRestClient(HttpClient httpClient, Action<SurrealRestClientOptionsBuilder> optionsBuilder)
	{
		var options = SurrealRestClientOptions.From(optionsBuilder);

		_httpClient = ConfigureHttpClient(httpClient, options);
		_options = options;
	}

	public async Task<IEnumerable<TResult>> CreateRecordAsync<TResult>(string tableName, string content, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendRequestAsync<TResult>(HttpMethod.Post, $"key/{tableName}", content, cancellationToken);
	}

	public async Task<TResult> CreateRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
		where TResult : class
	{
		IEnumerable<TResult> results = await SendRequestAsync<TResult>(HttpMethod.Post, $"key/{tableName}/{id}", content, cancellationToken);

		return results.Single();
	}

	public async Task DeleteAllRecordsAsync(string tableName, CancellationToken cancellationToken = default)
	{
		await SendRequestAsync(HttpMethod.Delete, $"key/{tableName}", cancellationToken);
	}

	public async Task DeleteRecordByIdAsync(string tableName, string id, CancellationToken cancellationToken = default)
	{
		await SendRequestAsync(HttpMethod.Delete, $"key/{tableName}/{id}", cancellationToken);
	}

	public async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendRequestAsync<TResult>(HttpMethod.Post, "sql", query, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> GetAllRecordsAsync<TResult>(string tableName, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendRequestAsync<TResult>(HttpMethod.Get, $"key/{tableName}", cancellationToken);
	}

	public async Task<TResult?> GetRecordByIdAsync<TResult>(string tableName, string id, CancellationToken cancellationToken = default)
		where TResult : class
	{
		IEnumerable<TResult> results = await SendRequestAsync<TResult>(HttpMethod.Get, $"key/{tableName}/{id}", cancellationToken);

		return results.FirstOrDefault();
	}

	public async Task<TResult> ModifyRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
		where TResult : class
	{
		IEnumerable<TResult> results = await SendRequestAsync<TResult>(HttpMethod.Patch, $"key/{tableName}/{id}", content, cancellationToken);

		return results.Single();
	}

	public async Task<TResult> UpsertRecordAsync<TResult>(string tableName, string id, string content, CancellationToken cancellationToken = default)
		where TResult : class
	{
		IEnumerable<TResult> results = await SendRequestAsync<TResult>(HttpMethod.Put, $"key/{tableName}/{id}", content, cancellationToken);

		return results.Single();
	}

	private static HttpClient ConfigureHttpClient(HttpClient httpClient, SurrealRestClientOptions options)
	{
		httpClient.BaseAddress = new Uri(options.Address);

		httpClient.DefaultRequestHeaders.Accept.Clear();
		httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		httpClient.DefaultRequestHeaders.Authorization = CreateAuthorizationHeader(options.Username, options.Password);

		httpClient.DefaultRequestHeaders.Add("DB", options.Database);
		httpClient.DefaultRequestHeaders.Add("NS", options.Namespace);

		return httpClient;
	}

	private static AuthenticationHeaderValue CreateAuthorizationHeader(string username, string password)
	{
		byte[] bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
		string base64 = Convert.ToBase64String(bytes);

		return new AuthenticationHeaderValue("Basic", base64);
	}

	private async Task<IEnumerable<TResult>> ParseResponseAsync<TResult>(HttpResponseMessage response, CancellationToken cancellationToken = default)
		where TResult : class
	{
		Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);

		SurrealRestErrorResponse? errorResponse =
			await _options.JsonProvider.DeserializeAsync<SurrealRestErrorResponse>(stream, cancellationToken);

		if (errorResponse is not null)
		{
			throw new Exception($"({errorResponse.Code}) {errorResponse.Information}. {errorResponse.Description}");
		}

		ExecuteQueryResponse<TResult>[]? queryResponse =
			await _options.JsonProvider.DeserializeAsync<ExecuteQueryResponse<TResult>[]>(stream, cancellationToken);

		if (queryResponse is null)
		{
			throw new SurrealDeserializationException<string, ExecuteQueryResponse<TResult>[]>();
		}

		ExecuteQueryResponse<TResult>? queryError =
			queryResponse.FirstOrDefault(result => result.Status == $"{ExecuteQueryStatusCode.ERR}");

		if (queryError is not null)
		{
			throw new SurrealQueryException(queryError.Detail);
		}

		return queryResponse.Select(result => result.Result);
	}

	private async Task SendRequestAsync(HttpMethod method, string endpoint, CancellationToken cancellationToken = default)
	{
		var request = new HttpRequestMessage(method, endpoint);

		HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

		await ParseResponseAsync<object>(response, cancellationToken);
	}

	private async Task<IEnumerable<TResult>> SendRequestAsync<TResult>(HttpMethod method, string endpoint, CancellationToken cancellationToken = default)
		where TResult : class
	{
		var request = new HttpRequestMessage(method, endpoint);

		HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

		return await ParseResponseAsync<TResult>(response, cancellationToken);
	}

	private async Task<IEnumerable<TResult>> SendRequestAsync<TResult>(HttpMethod method, string endpoint, string content, CancellationToken cancellationToken = default)
		where TResult : class
	{
		var request = new HttpRequestMessage(method, endpoint)
		{
			Content = new StringContent(content)
		};

		HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

		return await ParseResponseAsync<TResult>(response, cancellationToken);
	}
}

using System.Net.WebSockets;
using SurrealDB.Client.Enums;
using SurrealDB.Client.Exceptions;
using SurrealDB.Client.Responses;
using SurrealDB.Client.WebSocket;
using SurrealDB.Client.WebSocket.Events;

namespace SurrealDB.Client.Rpc;

public class SurrealRpcClient : ISurrealRpcClient, IDisposable
{
	private readonly SurrealRpcClientOptions _options;

	private readonly Dictionary<string, Action<string>> _responseHandlers = new();

	private Lazy<Task<IWebSocketClient>>? _lazyWebSocketClient;

	public SurrealRpcClient(ClientWebSocket socket, Action<SurrealRpcClientOptionsBuilder> optionsBuilder)
	{
		var options = SurrealRpcClientOptions.From(optionsBuilder);

		_lazyWebSocketClient = CreateLazyWebSocketClient(socket, options);
		_options = options;
	}

	public void Dispose()
	{
		Dispose(true);

		GC.SuppressFinalize(this);
	}

	public async Task<IEnumerable<TResult>> CreateRecordAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("create", new object[] { tableOrRecordId, data }, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> DeleteAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("delete", new object[] { tableOrRecordId }, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("query", new object[] { query }, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> ExecuteQueryAsync<TResult>(string query, IDictionary<string, object> parameters, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("query", new object[] { query, parameters }, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> GetAllRecordsAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("select", new object[] { tableOrRecordId }, cancellationToken);
	}

	public async Task<TResult?> GetRecordByIdAsync<TResult>(string tableOrRecordId, CancellationToken cancellationToken = default)
		where TResult : class
	{
		IEnumerable<TResult> results = await GetAllRecordsAsync<TResult>(tableOrRecordId, cancellationToken);

		return results.FirstOrDefault();
	}

	public async Task<IEnumerable<TResult>> ModifyAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("modify", new object[] { tableOrRecordId, data }, cancellationToken);
	}

	public async Task<IEnumerable<TResult>> UpdateRecordsAsync<TResult>(string tableOrRecordId, string data, CancellationToken cancellationToken = default)
		where TResult : class
	{
		return await SendMessageAsync<TResult>("update", new object[] { tableOrRecordId, data }, cancellationToken);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing)
		{
			return;
		}

		_lazyWebSocketClient?.Value.Result.Dispose();
		_lazyWebSocketClient?.Value.Dispose();
		_lazyWebSocketClient = null;
	}

	private Lazy<Task<IWebSocketClient>> CreateLazyWebSocketClient(ClientWebSocket socket, SurrealRpcClientOptions options)
	{
		socket.Options.SetRequestHeader("DB", options.Database);
		socket.Options.SetRequestHeader("NS", options.Namespace);

		return new Lazy<Task<IWebSocketClient>>(async () =>
		{
			var webSocketClient = new WebSocketClient(socket, client => client.WithUri(options.Address));

			webSocketClient.OnTextMessageReceived += HandleWebSocketMessage;

			await webSocketClient.OpenAsync();

			return webSocketClient;
		});
	}

	private void HandleWebSocketMessage(IWebSocketClient client, MessageReceivedEvent<string> @event, CancellationToken cancellationToken = default)
	{
		SurrealRpcResponse? response = _options.JsonProvider.Deserialize<SurrealRpcResponse>(@event.Message);

		if (response is null)
		{
			throw new SurrealException("Invalid response received from SurrealDB, missing 'id' property.");
		}

		_responseHandlers.TryGetValue(response.Id, out Action<string>? responseHandler);

		if (responseHandler is null)
		{
			throw new SurrealBugException($"No response handler found for request ID {response.Id}.");
		}

		responseHandler.Invoke(@event.Message);
	}

	private IEnumerable<TResult> ParseResponse<TResult>(string response)
		where TResult : class
	{
		SurrealRpcErrorResponse? errorResponse = _options.JsonProvider.Deserialize<SurrealRpcErrorResponse>(response);

		if (errorResponse is not null)
		{
			throw new SurrealQueryException($"{errorResponse.Error.Message} ({errorResponse.Error.Code})");
		}

		SurrealRpcResponse<ExecuteQueryResponse<TResult>[]>? queryResponse =
			_options.JsonProvider.Deserialize<SurrealRpcResponse<ExecuteQueryResponse<TResult>[]>>(response);

		if (queryResponse is null)
		{
			throw new SurrealDeserializationException<string, SurrealRpcResponse<ExecuteQueryResponse<TResult>[]>>();
		}

		ExecuteQueryResponse<TResult>? queryError =
			queryResponse.Result.FirstOrDefault(result => result.Status == $"{ExecuteQueryStatusCode.ERR}");

		if (queryError is not null)
		{
			throw new SurrealQueryException(queryError.Detail);
		}

		return queryResponse.Result.Select(result => result.Result);
	}

	private async Task<IEnumerable<TResponse>> SendMessageAsync<TResponse>(string method, IEnumerable<object> @params, CancellationToken cancellationToken = default)
		where TResponse : class
	{
		if (_lazyWebSocketClient is null)
		{
			throw new ObjectDisposedException(nameof(IWebSocketClient));
		}

		IWebSocketClient webSocketClient = await _lazyWebSocketClient.Value;

		var requestId = Guid.NewGuid().ToString();

		string serializedPayload = _options.JsonProvider.Serialize(new
		{
			Id = requestId,
			Method = method,
			Params = @params
		});

		await webSocketClient.SendAsync(serializedPayload, cancellationToken);

		return await WaitForResponseAsync<TResponse>(requestId, cancellationToken);
	}

	private async Task<IEnumerable<TResponse>> WaitForResponseAsync<TResponse>(string requestId, CancellationToken cancellationToken = default)
		where TResponse : class
	{
		var waitForResponse = new TaskCompletionSource<IEnumerable<TResponse>>();

		_responseHandlers[requestId] = response =>
		{
			try
			{
				IEnumerable<TResponse> result = ParseResponse<TResponse>(response);

				waitForResponse.SetResult(result);
			}
			catch (Exception exception)
			{
				waitForResponse.SetException(exception);
			}
		};

		try
		{
			return await waitForResponse.Task.WaitAsync(_options.Timeout, cancellationToken);
		}
		finally
		{
			_responseHandlers.Remove(requestId);
		}
	}
}

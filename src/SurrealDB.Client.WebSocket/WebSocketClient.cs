namespace SurrealDB.Client.WebSocket;

using System.Net.WebSockets;
using Events;

public class WebSocketClient : IWebSocketClient
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly WebSocketClientOptions _options;
    private readonly ClientWebSocket _socket;

    public WebSocketClient(ClientWebSocket socket, Action<WebSocketClientOptionsBuilder> optionsBuilder)
    {
        _options = BuildOptions(optionsBuilder);
        _socket = socket;
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    public bool IsSocketOpened => _socket.State == WebSocketState.Open;

    public event MessagedReceivedHandler<byte[]>? OnBinaryMessageReceived;

    public event MessagedReceivedHandler<string>? OnTextMessageReceived;

    public async Task CloseAsync()
    {
        await CloseAsync(_cancellationTokenSource.Token);
    }

    public async Task CloseAsync(CancellationToken cancellationToken)
    {
        if (IsSocketOpened)
        {
            await _socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken);

            _cancellationTokenSource.Cancel();
        }
    }

    public async Task OpenAsync()
    {
        if (IsSocketOpened)
        {
            return;
        }

        await _socket.ConnectAsync(_options.Uri, _cancellationTokenSource.Token);

        _ = Task.Run(async () =>
        {
            try
            {
                await ListenForMessagesAsync(_socket, _options.ReceiveBufferSize, _cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                // Ignore as this should only occur when CloseAsync is called (which cancels the CancellationTokenSource) 
            }
        }, _cancellationTokenSource.Token);
    }

    public async Task SendAsync(string message)
    {
        await SendAsync(message, _cancellationTokenSource.Token);
    }

    public async Task SendAsync(string message, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return;
        }

        var bytes = _options.Encoding.GetBytes(message);
        var buffer = new ArraySegment<byte>(bytes);

        await _socket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        _cancellationTokenSource.Dispose();

        _socket.Abort();
        _socket.Dispose();
    }

    private static WebSocketClientOptions BuildOptions(Action<WebSocketClientOptionsBuilder> optionsBuilder)
    {
        var builder = new WebSocketClientOptionsBuilder();

        optionsBuilder(builder);

        return builder.Options;
    }

    private async Task ListenForMessagesAsync(WebSocket socket, int bufferSize, CancellationToken cancellationToken = default)
    {
        var buffer = new ArraySegment<byte>(new byte[bufferSize]);

        while (IsSocketOpened && !cancellationToken.IsCancellationRequested)
        {
            WebSocketReceiveResult received;

            await using var messageStream = new MemoryStream();

            while (true)
            {
                received = await socket.ReceiveAsync(buffer, cancellationToken);

                var chunk = buffer.Array.AsMemory(buffer.Offset, received.Count);

                await messageStream.WriteAsync(chunk, cancellationToken);

                if (received.EndOfMessage)
                {
                    break;
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            messageStream.Seek(0, SeekOrigin.Begin);

            switch (received.MessageType)
            {
                case WebSocketMessageType.Close:
                    await _socket.CloseOutputAsync(WebSocketCloseStatus.Empty, string.Empty, cancellationToken);
                    return;
                case WebSocketMessageType.Text:
                    HandleTextMessage(messageStream, cancellationToken);
                    break;
                case WebSocketMessageType.Binary:
                    HandleBinaryMessage(messageStream, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException($"Received unknown message type: {received.MessageType}");
            }
        }
    }

    private void HandleBinaryMessage(MemoryStream stream, CancellationToken cancellationToken = default)
    {
        var message = stream.ToArray();

        OnBinaryMessageReceived?.Invoke(this, new MessageReceivedEvent<byte[]>(message), cancellationToken);
    }

    private void HandleTextMessage(MemoryStream stream, CancellationToken cancellationToken = default)
    {
        var message = _options.Encoding.GetString(stream.ToArray());

        OnTextMessageReceived?.Invoke(this, new MessageReceivedEvent<string>(message), cancellationToken);
    }
}

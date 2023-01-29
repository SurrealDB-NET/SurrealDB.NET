namespace SurrealDB.Client.WebSocket;

using Events;

/// <summary>
///     Represents a method that will handle the <see cref="IWebSocketClient.OnBinaryMessageReceived" /> or
///     <see cref="IWebSocketClient.OnTextMessageReceived" /> event of a <see cref="IWebSocketClient" />.
/// </summary>
/// <typeparam name="TMessage">The type of the messaged received</typeparam>
public delegate void MessagedReceivedHandler<TMessage>(IWebSocketClient client, MessageReceivedEvent<TMessage> @event, CancellationToken cancellationToken = default);

public interface IWebSocketClient : IDisposable
{
    /// <summary>
    ///     Gets a value indicating whether the socket is opened.
    /// </summary>
    public bool IsSocketOpened { get; }

    /// <summary>
    ///     Occurs when a binary message is received from the server.
    /// </summary>
    public event MessagedReceivedHandler<byte[]>? OnBinaryMessageReceived;

    /// <summary>
    ///     Occurs when a text message is received from the server.
    /// </summary>
    public event MessagedReceivedHandler<string>? OnTextMessageReceived;

    /// <summary>
    ///     Closes the socket. If the socket is already closed, this method is no-op.
    /// </summary>
    public Task CloseAsync();

    /// <summary>
    ///     Closes the socket. If the socket is already closed, this method is no-op.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation
    /// </param>
    public Task CloseAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Opens the socket and starts receiving messages. If the socket is already opened, this method is no-op.
    /// </summary>
    public Task OpenAsync();

    /// <summary>
    ///     Sends a message to the server.
    /// </summary>
    /// <param name="message">The message to be sent</param>
    public Task SendAsync(string message);

    /// <summary>
    ///     Sends a message to the server.
    /// </summary>
    /// <param name="message">The message to be sent</param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation
    /// </param>
    public Task SendAsync(string message, CancellationToken cancellationToken);
}

namespace SurrealDB.Client.WebSocket;

using System.Text;

/// <summary>
///     Builder for <see cref="WebSocketClientOptions" />.
/// </summary>
public sealed class WebSocketClientOptionsBuilder
{
    /// <summary>
    ///     The options to build.
    /// </summary>
    /// <remarks>
    ///     The default value is a new instance of <see cref="WebSocketClientOptions" />.
    /// </remarks>
    internal WebSocketClientOptions Options { get; } = new();

    /// <summary>
    ///     The encoding to use when sending and receiving messages.
    /// </summary>
    /// <remarks>
    ///     The default value is <see cref="System.Text.Encoding.UTF8" />.
    /// </remarks>
    public WebSocketClientOptionsBuilder WithEncoding(Encoding encoding)
    {
        Options.Encoding = encoding;

        return this;
    }

    /// <summary>
    ///     The size of the buffer to use when receiving messages.
    /// </summary>
    /// <remarks>
    ///     The default value is 4096.
    /// </remarks>
    public WebSocketClientOptionsBuilder WithReceiveBufferSize(int receiveBufferSize)
    {
        Options.ReceiveBufferSize = receiveBufferSize;

        return this;
    }

    /// <summary>
    ///     The URI to connect to.
    /// </summary>
    public WebSocketClientOptionsBuilder WithUri(string uri)
    {
        Options.Uri = new Uri(uri);

        return this;
    }
}

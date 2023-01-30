namespace SurrealDB.Client.WebSocket;

using System.Text;

/// <summary>
///     Options for the <see cref="WebSocketClient" />.
/// </summary>
internal class WebSocketClientOptions
{
    /// <summary>
    ///     The encoding to use when sending and receiving messages.
    /// </summary>
    /// <remarks>
    ///     The default value is <see cref="System.Text.Encoding.UTF8" />.
    /// </remarks>
    internal Encoding Encoding { get; set; } = Encoding.UTF8;

    /// <summary>
    ///     The size of the buffer to use when receiving messages.
    /// </summary>
    /// <remarks>
    ///     The default value is 4096.
    /// </remarks>
    internal int ReceiveBufferSize { get; set; } = 4096;

    /// <summary>
    ///     The URI to connect to.
    /// </summary>
    internal Uri Uri { get; set; } = default!;
}

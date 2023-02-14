namespace SurrealDB.Client.WebSocket.Events;

/// <summary>
///     Event that is raised when a message is received from the server.
/// </summary>
/// <param name="Message">The messaged that was received from the server</param>
/// <typeparam name="TMessage">The type of the messaged received</typeparam>
public record MessageReceivedEvent<TMessage>(TMessage Message);

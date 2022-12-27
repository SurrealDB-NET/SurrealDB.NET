namespace SurrealDB.Client;

public interface ISurrealClientOptions
{
    public string BaseAddress { get; }
    
    public string Database { get; }
    
    public string Namespace { get; }
    
    public string Password { get; }
    
    public string Username { get; }
}

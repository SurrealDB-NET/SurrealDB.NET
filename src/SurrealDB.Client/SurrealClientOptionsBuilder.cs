// ReSharper disable UnusedMethodReturnValue.Global

namespace SurrealDB.Client;

#pragma warning disable CS8618
internal class SurrealClientOptions : ISurrealClientOptions
{
    public string BaseAddress { get; set; }
    
    public string Database { get; set; }

    public string Namespace { get; set; }

    public string Password { get; set; }

    public string Username { get; set; }
}
#pragma warning restore CS8618

public class SurrealClientOptionsBuilder
{
    private readonly SurrealClientOptions _options;

    public SurrealClientOptionsBuilder()
    {
        _options = new SurrealClientOptions();
    }

    public SurrealClientOptionsBuilder WithBaseAddress(string baseAddress)
    {
        _options.BaseAddress = baseAddress;

        return this;
    }

    public SurrealClientOptionsBuilder WithDatabase(string database)
    {
        _options.Database = database;

        return this;
    }

    public SurrealClientOptionsBuilder WithNamespace(string @namespace)
    {
        _options.Namespace = @namespace;

        return this;
    }

    public SurrealClientOptionsBuilder WithPassword(string password)
    {
        _options.Password = password;

        return this;
    }

    public SurrealClientOptionsBuilder WithUsername(string username)
    {
        _options.Username = username;

        return this;
    }

    internal ISurrealClientOptions Build()
    {
        return _options;
    }
}

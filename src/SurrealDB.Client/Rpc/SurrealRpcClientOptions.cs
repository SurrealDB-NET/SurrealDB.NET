namespace SurrealDB.Client.Rpc;

using JsonProviders;

internal class SurrealRpcClientOptions
{
#pragma warning disable CS8618 Non-nullable field is uninitialized. Consider declaring as nullable.
    public string Address { get; set; }

    public string Database { get; set; }

    public IJsonProvider JsonProvider { get; set; } = new DefaultJsonProvider();

    public string Namespace { get; set; }

    public string Password { get; set; }

    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

    public string Username { get; set; }
#pragma warning restore CS8618

    public static SurrealRpcClientOptions From(Action<SurrealRpcClientOptionsBuilder> builder)
    {
        var optionsBuilder = new SurrealRpcClientOptionsBuilder();

        builder(optionsBuilder);

        return optionsBuilder.Options;
    }
}

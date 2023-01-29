namespace SurrealDB.Client.Rest;

using JsonProviders;

internal class SurrealRestClientOptions
{
#pragma warning disable CS8618 Non-nullable field is uninitialized. Consider declaring as nullable.
    public string Address { get; set; }

    public string Database { get; set; }

    public IJsonProvider JsonProvider { get; set; } = new DefaultJsonProvider();

    public string Namespace { get; set; }

    public string Password { get; set; }

    public string Username { get; set; }
#pragma warning restore CS8618

    public static SurrealRestClientOptions From(Action<SurrealRestClientOptionsBuilder> builder)
    {
        var optionsBuilder = new SurrealRestClientOptionsBuilder();

        builder(optionsBuilder);

        return optionsBuilder.Options;
    }
}

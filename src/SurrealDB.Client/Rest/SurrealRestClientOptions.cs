using SurrealDB.Client.JsonProviders;

namespace SurrealDB.Client.Rest;

internal class SurrealRestClientOptions
{
	public string Address { get; set; } = string.Empty;

	public string Database { get; set; } = string.Empty;

	public IJsonProvider JsonProvider { get; set; } = new DefaultJsonProvider();

	public string Namespace { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;

	public string Username { get; set; } = string.Empty;

	public static SurrealRestClientOptions From(Action<SurrealRestClientOptionsBuilder> builder)
	{
		var optionsBuilder = new SurrealRestClientOptionsBuilder();

		builder(optionsBuilder);

		return optionsBuilder.Options;
	}
}

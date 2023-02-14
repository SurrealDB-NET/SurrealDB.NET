using SurrealDB.Client.JsonProviders;

namespace SurrealDB.Client.Rpc;

internal class SurrealRpcClientOptions
{
	public string Address { get; set; } = string.Empty;

	public string Database { get; set; } = string.Empty;

	public IJsonProvider JsonProvider { get; set; } = new DefaultJsonProvider();

	public string Namespace { get; set; } = string.Empty;

	public string Password { get; set; } = string.Empty;

	public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

	public string Username { get; set; } = string.Empty;

	public static SurrealRpcClientOptions From(Action<SurrealRpcClientOptionsBuilder> builder)
	{
		var optionsBuilder = new SurrealRpcClientOptionsBuilder();

		builder(optionsBuilder);

		return optionsBuilder.Options;
	}
}

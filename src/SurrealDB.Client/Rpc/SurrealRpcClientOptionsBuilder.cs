using SurrealDB.Client.JsonProviders;

namespace SurrealDB.Client.Rpc;

public class SurrealRpcClientOptionsBuilder
{
	internal SurrealRpcClientOptions Options { get; } = new();

	public SurrealRpcClientOptionsBuilder WithAddress(string baseAddress)
	{
		Options.Address = baseAddress;

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithDatabase(string database)
	{
		Options.Database = database;

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithJsonProvider(IJsonProvider jsonProvider)
	{
		Options.JsonProvider = jsonProvider;

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithNamespace(string @namespace)
	{
		Options.Namespace = @namespace;

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithPassword(string password)
	{
		Options.Password = password;

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithTimeout(uint timeoutSeconds)
	{
		Options.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

		return this;
	}

	public SurrealRpcClientOptionsBuilder WithUsername(string username)
	{
		Options.Username = username;

		return this;
	}
}

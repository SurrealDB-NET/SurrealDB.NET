using SurrealDB.Client.JsonProviders;

namespace SurrealDB.Client.Rest;

public class SurrealRestClientOptionsBuilder
{
	internal SurrealRestClientOptions Options { get; } = new();

	public SurrealRestClientOptionsBuilder WithAddress(string baseAddress)
	{
		Options.Address = baseAddress;

		return this;
	}

	public SurrealRestClientOptionsBuilder WithDatabase(string database)
	{
		Options.Database = database;

		return this;
	}

	public SurrealRestClientOptionsBuilder WithJsonProvider(IJsonProvider jsonProvider)
	{
		Options.JsonProvider = jsonProvider;

		return this;
	}

	public SurrealRestClientOptionsBuilder WithNamespace(string @namespace)
	{
		Options.Namespace = @namespace;

		return this;
	}

	public SurrealRestClientOptionsBuilder WithPassword(string password)
	{
		Options.Password = password;

		return this;
	}

	public SurrealRestClientOptionsBuilder WithUsername(string username)
	{
		Options.Username = username;

		return this;
	}
}

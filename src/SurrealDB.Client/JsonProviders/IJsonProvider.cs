namespace SurrealDB.Client.JsonProviders;

public interface IJsonProvider
{
	public TValue? Deserialize<TValue>(string json);

	public Task<TValue?> DeserializeAsync<TValue>(Stream stream, CancellationToken cancellationToken = default);

	public string Serialize(object @object);
}

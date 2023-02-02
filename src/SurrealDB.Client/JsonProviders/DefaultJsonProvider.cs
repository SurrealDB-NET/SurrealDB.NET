using System.Text.Json;

namespace SurrealDB.Client.JsonProviders;

public class DefaultJsonProvider : IJsonProvider
{
	private readonly JsonSerializerOptions _options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

	public TValue? Deserialize<TValue>(string json)
		=> JsonSerializer.Deserialize<TValue>(json, _options);

	public async Task<TValue?> DeserializeAsync<TValue>(Stream stream, CancellationToken cancellationToken = default)
		=> await JsonSerializer.DeserializeAsync<TValue>(stream, _options, cancellationToken);

	public string Serialize(object @object)
		=> JsonSerializer.Serialize(@object, _options);
}

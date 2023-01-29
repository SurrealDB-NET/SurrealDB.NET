namespace SurrealDB.Client.JsonProviders;

using System.Text.Json;

public class DefaultJsonProvider : IJsonProvider
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public TValue? Deserialize<TValue>(string json)
    {
        return JsonSerializer.Deserialize<TValue>(json, _options);
    }

    public async Task<TValue?> DeserializeAsync<TValue>(Stream stream, CancellationToken cancellationToken = default)
    {
        return await JsonSerializer.DeserializeAsync<TValue>(stream, _options, cancellationToken);
    }

    public string Serialize(object @object)
    {
        return JsonSerializer.Serialize(@object, _options);
    }
}

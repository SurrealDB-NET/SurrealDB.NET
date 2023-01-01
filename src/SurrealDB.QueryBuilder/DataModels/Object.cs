using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace SurrealDB.QueryBuilder.DataModels;

public sealed class Object : IDictionary<string, object?>
{
    private readonly IDictionary<string, object?> _properties;

    public Object()
        => _properties = new Dictionary<string, object?>();

    public Object(IDictionary<string, object?> properties)
        => _properties = new Dictionary<string, object?>(properties);

    public Object(IEnumerable<KeyValuePair<string, object?>> properties)
        => _properties = new Dictionary<string, object?>(properties);

    public object? this[string key]
    {
        get => _properties[key];
        set => _properties[key] = value;
    }

    public ICollection<string> Keys => _properties.Keys;

    public ICollection<object?> Values => _properties.Values;

    public int Count => _properties.Count;

    public bool IsReadOnly => false;

    public void Add(string key, object? value)
        => _properties.Add(key, value);

    public void Add(KeyValuePair<string, object?> item)
        => _properties.Add(item.Key, item.Value);

    public void Clear()
        => _properties.Clear();

    public bool Contains(KeyValuePair<string, object?> item)
        => _properties.Contains(item);

    public bool ContainsKey(string key)
        => _properties.ContainsKey(key);

    /// <inheritdoc/>
    public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
        => _properties.CopyTo(array, arrayIndex);

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        => _properties.GetEnumerator();

    public bool Remove(string key)
        => _properties.Remove(key);

    public bool Remove(KeyValuePair<string, object?> item)
        => _properties.Remove(item);

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out object? value)
        => _properties.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator()
        => _properties.GetEnumerator();
}

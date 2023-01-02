namespace SurrealDB.QueryBuilder.DataModels;

using System.Collections;
using System.Numerics;
using Translators;

/// <summary>
/// Represents an object containing key value pairs where the value can be any type. It is equivalent to SurrealDB's Object data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/simple"/>
/// </summary>
public class Object : IDictionary<string, object?>
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

    public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
        => _properties.CopyTo(array, arrayIndex);

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        => _properties.GetEnumerator();

    public bool Remove(string key)
        => _properties.Remove(key);

    public bool Remove(KeyValuePair<string, object?> item)
        => _properties.Remove(item);

    public bool TryGetValue(string key, out object? value)
        => _properties.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator()
        => _properties.GetEnumerator();

    public override string ToString()
    {
        var output = new List<string>();

        foreach (var (key, value) in _properties)
        {
            var translatedValue = value switch
            {
                null => "null",
                char @char => PrimitiveTranslator.Translate(@char),
                string @string => PrimitiveTranslator.Translate(@string),
                bool @bool => PrimitiveTranslator.Translate(@bool),
                sbyte @sbyte => PrimitiveTranslator.Translate(@sbyte),
                byte @byte => PrimitiveTranslator.Translate(@byte),
                short @short => PrimitiveTranslator.Translate(@short),
                ushort @ushort => PrimitiveTranslator.Translate(@ushort),
                int @int => PrimitiveTranslator.Translate(@int),
                uint @uint => PrimitiveTranslator.Translate(@uint),
                long @long => PrimitiveTranslator.Translate(@long),
                ulong @ulong => PrimitiveTranslator.Translate(@ulong),
                float @float => PrimitiveTranslator.Translate(@float),
                double @double => PrimitiveTranslator.Translate(@double),
                decimal @decimal => PrimitiveTranslator.Translate(@decimal),
                BigInteger bigInteger => PrimitiveTranslator.Translate(bigInteger),
                None none => PrimitiveTranslator.Translate(none),
                Array array => array.ToString(),
                Object obj => obj.ToString(),
                IEnumerable enumerable => Array.Translate(enumerable),
                _ => throw new NotSupportedException($"The type {value.GetType()} is not supported.")
            };

            output.Add($"{key}:{translatedValue}");
        }

        return $"{{{string.Join(",", output)}}}";
    }
}

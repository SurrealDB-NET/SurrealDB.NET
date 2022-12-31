namespace SurrealDB.QueryBuilder.DataModels;

using System.Collections;

public class Object : IEnumerable
{
    private readonly IDictionary<string, object?> _items = new Dictionary<string, object?>();

    public Object()
    {
    }

    public Object(IDictionary<string, object?> items)
    {
        _items = items;
    }

    public Object(IEnumerable<KeyValuePair<string, object?>> items)
    {
        foreach (var (key, value) in items)
        {
            _items.Add(key, value);
        }
    }

    public object? this[string key]
    {
        get => _items[key];
        set => _items[key] = value;
    }

    public int Count
        => _items.Count;

    public IEnumerable<string> Keys
        => _items.Keys;

    public IEnumerable<object?> Values
        => _items.Values;

    public void Add(string key, object? value)
        => _items.Add(key, value);

    public void Clear()
        => _items.Clear();

    public bool Contains(string key)
        => _items.ContainsKey(key);

    public IEnumerator GetEnumerator()
        => _items.GetEnumerator();
    
    public bool Remove(string key)
        => _items.Remove(key);

    public bool TryGetValue(string key, out object? value)
        => _items.TryGetValue(key, out value);

    public override string ToString()
    {
        var body = new List<string>();

        foreach (var (key, value) in _items)
        {
            body.Add($"{key}:");

            switch (value)
            {
                case bool boolean:
                    body.Add(boolean.ToString().ToLower());
                    break;
                case IEnumerable<bool> booleans:
                    body.Add(string.Join(",", booleans.Select(boolean => boolean.ToString().ToLower())));
                    break;
                case sbyte:
                case byte:
                case short:
                case int:
                case uint:
                case long:
                case ulong:
                case nint:
                case nuint:
                case float:
                case double:
                case decimal:
                    body.Add(value.ToString()!);
                    break;
                case IEnumerable<sbyte>:
                case IEnumerable<byte>:
                case IEnumerable<short>:
                case IEnumerable<int>:
                case IEnumerable<uint>:
                case IEnumerable<long>:
                case IEnumerable<ulong>:
                case IEnumerable<nint>:
                case IEnumerable<nuint>:
                case IEnumerable<float>:
                case IEnumerable<double>:
                case IEnumerable<decimal>:
                    body.Add(string.Join(",", value));
                    break;
                case char:
                case string:
                    body.Add($"\"{value}\"");
                    break;
                case IEnumerable<char>:
                case IEnumerable<string>:
                {
                    var strings = value as IEnumerable<string> ?? Array.Empty<string>();
                    body.Add(string.Join(",", strings.Select(v => $"\"{v}\"")));
                    break;
                }
                case Object obj:
                    body.Add(obj.ToString());
                    break;
                case IEnumerable<Object> objects:
                    body.Add(string.Join(",", objects.Select(obj => obj.ToString())));
                    break;
                case null:
                    body.Add("null");
                    break;
                default:
                    throw new NotSupportedException();
            }

            body.Add(","); // Add comma to separate each entry
        }

        body[^1] = ""; // Remove last comma

        return "{" + body + "}";
    }
}

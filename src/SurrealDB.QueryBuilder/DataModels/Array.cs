using System.Collections;

namespace SurrealDB.QueryBuilder.DataModels;

using System.Numerics;
using Translators;

/// <summary>
/// Represents an array containing items of any type. It is equivalent to SurrealDB's Array data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/simple"/>
/// </summary>
public class Array : IEnumerable
{
    private readonly List<object?> _items;

    public Array()
        => _items = new();

    public Array(params object[] items)
        => _items = new(items);

    public Array(IEnumerable<object> items)
        => _items = new(items);

    public static implicit operator Array(object[] items)
        => new(items);

    public static string Translate(IEnumerable items)
    {
        var output = new List<string>();

        foreach (var item in items)
        {
            var translatedItem = item switch
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
                SchemalessObject obj => obj.ToString(),
                IEnumerable enumerable => Translate(enumerable),
                _ => throw new NotSupportedException($"The type {item.GetType()} is not supported.")
            };

            output.Add(translatedItem);
        }

        return $"[{string.Join(",", output)}]";
    }

    public void Add(object item)
        => _items.Add(item);

    public void AddRange(IEnumerable<object> items)
        => _items.AddRange(items);

    public IEnumerator GetEnumerator()
        => _items.GetEnumerator();

    public override string ToString()
        => Translate(_items);
}

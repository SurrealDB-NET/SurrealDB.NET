namespace SurrealDB.QueryBuilder.Translators;

using System.Collections;
using System.Numerics;
using System.Reflection;
using DataModels;
using Functions;
using SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Translates an object to a SurrealQL object
/// </summary>
public static class ObjectTranslator
{
    public static string Translate(object? @object)
        => @object switch
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
            nint nint => PrimitiveTranslator.Translate(nint),
            nuint nuint => PrimitiveTranslator.Translate(nuint),
            BigInteger bigInteger => PrimitiveTranslator.Translate(bigInteger),
            None none => PrimitiveTranslator.Translate(none),
            Function function => FunctionTranslator.Translate(function),
            SchemalessObject obj => obj.ToString(),
            IEnumerable enumerable => EnumerableTranslator.Translate(enumerable),
            IGeometry geometry => ObjectTranslator.Translate(geometry.ToGeoJson()),
            not null => TranslateUnknownObject(@object)
        };

    private static string TranslateUnknownObject(object unknownObject)
    {
        var type = unknownObject.GetType();

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var @object = new SchemalessObject();

        foreach (var field in fields)
        {
            @object.Add(field.Name, field.GetValue(unknownObject));
        }

        foreach (var property in properties)
        {
            @object.Add(property.Name, property.GetValue(unknownObject));
        }

        return @object.ToString();
    }
}

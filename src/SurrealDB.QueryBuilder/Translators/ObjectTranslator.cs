using System.Collections;
using System.Numerics;
using System.Reflection;
using System.Text;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;

namespace SurrealDB.QueryBuilder.Translators;

/// <summary>
/// lol
/// </summary>
public static class ObjectTranslator
{
    public static string Translate(object? @object)
    {
        switch (@object)
        {
            case null:
                return "null";
            case None none:
                return PrimitiveTranslator.Translate(none);
            case bool @bool:
                return PrimitiveTranslator.Translate(@bool);
            case char @char:
                return PrimitiveTranslator.Translate(@char);
            case string @string:
                return PrimitiveTranslator.Translate(@string);
            case Duration duration:
                return DateTimeTranslator.Translate(duration);
            case DateTime dateTime:
                return DateTimeTranslator.Translate(dateTime);
            case DateTimeOffset dateTimeOffset:
                return DateTimeTranslator.Translate(dateTimeOffset);
        }

        var type = @object.GetType();

        // Number types
        if (type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INumber<>)))
        {
            var method = typeof(PrimitiveTranslator).GetMethod(nameof(PrimitiveTranslator.Translate), BindingFlags.Static | BindingFlags.NonPublic);
            var genericMethod = method!.MakeGenericMethod(type);
            return (string)genericMethod.Invoke(null, new object[] { @object })!;
        }

        // Array types
        if (type.IsArray || type.IsAssignableTo(typeof(IEnumerable)))
        {
            var method = typeof(ArrayTranslator).GetMethod(nameof(ArrayTranslator.Translate), BindingFlags.Static | BindingFlags.NonPublic);
            var genericMethod = method!.MakeGenericMethod(type.GetElementType()!);
            return (string)genericMethod.Invoke(null, new object[] { @object })!;
        }

        // Object types
        var result = new StringBuilder("{");

        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var field in fields)
            result.Append($"{field.Name}:{Translate(field.GetValue(@object))},");

        foreach (var property in properties)
            result.Append($"{property.Name}:{Translate(property.GetValue(@object))},");

        result.Remove(result.Length - 1, 1); // Remove last comma

        result.Append("}");

        return result.ToString();
    }
}

using System.Collections;
using System.Numerics;
using System.Reflection;
using SurrealDB.QueryBuilder.DataModels;

namespace SurrealDB.QueryBuilder.Translators;

internal static class ObjectTranslator
{
    internal static string Translate(object? @object)
    {
        if (@object is null)
            return "null";
        if (@object is None)
            return PrimitiveTranslator.Translate((None)@object);
        if (@object is bool @bool)
            return PrimitiveTranslator.Translate(@bool);
        if (@object is char @char)
            return PrimitiveTranslator.Translate(@char);
        if (@object is string @string)
            return PrimitiveTranslator.Translate(@string);
        if (@object is DateTime @DateTime)
            return PrimitiveTranslator.Translate(@DateTime);

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

        throw new NotSupportedException($"The type {type} is not supported.");
    }
}

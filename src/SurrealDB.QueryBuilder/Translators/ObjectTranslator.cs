using System.Collections;
using System.Numerics;
using System.Reflection;
using SurrealDB.QueryBuilder.DataModels;
using SurrealDB.QueryBuilder.DataModels.Geometry;

namespace SurrealDB.QueryBuilder.Translators;

/// <summary>
///     Translates an object to a SurrealQL object
/// </summary>
public static class ObjectTranslator
{
	public static string Translate(object? @object)
	{
		return @object switch
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
			DateTime dateTime => DateTimeTranslator.Translate(dateTime),
			DateTimeOffset dateTimeOffset => DateTimeTranslator.Translate(dateTimeOffset),
			Duration duration => DateTimeTranslator.Translate(duration),
			Half half => PrimitiveTranslator.Translate(half),
			SchemalessObject schemalessObject => $"{schemalessObject}",
			IEnumerable enumerable => EnumerableTranslator.Translate(enumerable),
			IGeometry geometry => Translate(geometry.ToGeoJson()),
			_ => TranslateUnknownObject(@object)
		};
	}

	private static string TranslateUnknownObject(object unknownObject)
	{
		Type type = unknownObject.GetType();

		FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
		PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

		var @object = new SchemalessObject();

		foreach (FieldInfo field in fields)
		{
			@object.Add(field.Name, field.GetValue(unknownObject));
		}

		foreach (PropertyInfo property in properties)
		{
			@object.Add(property.Name, property.GetValue(unknownObject));
		}

		return @object.ToString();
	}
}

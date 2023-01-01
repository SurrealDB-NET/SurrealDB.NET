using System.Numerics;
using System.Text;
using SurrealDB.QueryBuilder.DataModels.Geometry;

namespace SurrealDB.QueryBuilder.DataModels;

internal static class SurrealifyExtensions
{
    internal static string Surrealify<TNumber>(this TNumber number) where TNumber : INumber<TNumber>
        => $"{number}";

    internal static string Surrealify(this bool boolean)
        => boolean ? "true" : "false";

    internal static string Surrealify(this string @string)
        => $"\"{@string}\"";

    internal static string Surrealify(this char character)
        => $"\"{character}\"";

    internal static string Surrealify(this Guid guid)
        => $"\"{guid}\"";

    internal static string Surrealify(this None none)
        => "none";

    internal static string Surrealify(this IGeometry geometry)
        => geometry switch
        {
            Point point => $"{{type: \"Point\", coordinates:[{point.Coordinates[0]}, {point.Coordinates[1]}]}}",
            Line line  => $"{{type: \"LineString\", coordinates:[{string.Join(", ", line.Coordinates.Select(point => point.Surrealify()))}]}}",
            Polygon polygon => $"{{type: \"Polygon\", coordinates:[[{string.Join(", ", polygon.Coordinates.Select(point => point.Surrealify()))}]]}}",
            MultiPoint multiPoint => $"{{type: \"MultiPoint\", coordinates:[{string.Join(", ", multiPoint.Coordinates.Select(point => point.Surrealify()))}]}}",
            MultiLine multiLine => $"{{type: \"MultiLineString\", coordinates:[{string.Join(", ", multiLine.Coordinates.Select(line => line.Surrealify()))}]}}",
            MultiPolygon multiPolygon => $"{{type: \"MultiPolygon\", coordinates:[{string.Join(", ", multiPolygon.Coordinates.Select(polygon => polygon.Surrealify()))}]}}",
            GeometryCollection geometryCollection => $"{{type: \"GeometryCollection\", geometries:[{string.Join(", ", geometryCollection.Geometries.Select(geometry => geometry.Surrealify()))}]}}",
            _ => throw new NotImplementedException()
        };
}
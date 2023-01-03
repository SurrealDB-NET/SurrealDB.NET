namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON Polygon value for storing a geometric area. It is equivalent to SurrealDB's Polygon data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#polygon"/>
/// </summary>
public class Polygon : IGeometry, IEquatable<Polygon>
{
    public Point[] Coordinates { get; }

    public Polygon(params Point[] points)
        => Coordinates = points;

    public Polygon(IEnumerable<Point> lines)
        => Coordinates = lines.ToArray();

    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(Polygon) }, { "coordinates", CoordinatesOnly() } };

    internal decimal[][][] CoordinatesOnly()
        => new[] { Coordinates.Select(point => point.CoordinatesOnly()).ToArray() };

    public bool Equals(Polygon? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => Equals(value as Polygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(Polygon? left, Polygon? right)
        => Equals(left, right);

    public static bool operator !=(Polygon? left, Polygon? right)
        => !Equals(left, right);
}

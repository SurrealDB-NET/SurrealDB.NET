namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON Polygon value for storing a geometric area. It is equivalent to SurrealDB's Polygon data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#polygon"/>
/// </summary>
public sealed class Polygon : IGeometry, IEquatable<Polygon>
{
    public Point[] Coordinates { get; set; }

    public Polygon(Point[] coordinates)
        => Coordinates = coordinates;

    public Polygon(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(Polygon? value)
        => value is Polygon
        && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is Polygon polygon
        && Equals(polygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(Polygon? left, Polygon? right)
        => Equals(left, right);

    public static bool operator !=(Polygon? left, Polygon? right)
        => !Equals(left, right);
}
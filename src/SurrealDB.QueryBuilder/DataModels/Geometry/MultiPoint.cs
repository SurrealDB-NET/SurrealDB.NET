namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiPoint value which contains multiple geometry points. It is equivalent to SurrealDB's MultiPoint data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multipoint"/>
/// </summary>
public class MultiPoint : IGeometry, IEquatable<MultiPoint>
{
    public Point[] Coordinates { get; }

    public MultiPoint(params Point[] points)
        => Coordinates = points;

    public MultiPoint(IEnumerable<Point> points)
        => Coordinates = points.ToArray();

    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(MultiPoint) }, { "coordinates", Coordinates } };

    public bool Equals(MultiPoint? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => Equals(value as MultiPoint);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiPoint? left, MultiPoint? right)
        => Equals(left, right);

    public static bool operator !=(MultiPoint? left, MultiPoint? right)
        => !Equals(left, right);
}

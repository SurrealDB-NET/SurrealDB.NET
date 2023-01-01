namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiPoint value which contains multiple geometry points. It is equivalent to SurrealDB's MultiPoint data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multipoint"/>
/// </summary>
public sealed class MultiPoint : IGeometry, IEquatable<MultiPoint>
{
    public Point[] Coordinates { get; set; }

    public MultiPoint(Point[] coordinates)
        => Coordinates = coordinates;

    public MultiPoint(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(MultiPoint? value)
        => value is MultiPoint
        && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiPoint multiPoint
        && Equals(multiPoint);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiPoint? left, MultiPoint? right)
        => Equals(left, right);

    public static bool operator !=(MultiPoint? left, MultiPoint? right)
        => !Equals(left, right);
}
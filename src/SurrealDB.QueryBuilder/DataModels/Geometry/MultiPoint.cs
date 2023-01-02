namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiPoint value which contains multiple geometry points. It is equivalent to SurrealDB's MultiPoint data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multipoint"/>
/// </summary>
public class MultiPoint : Object, IGeometry, IEquatable<MultiPoint>
{
    public decimal[][] Coordinates { get; }

    public MultiPoint(params (decimal x, decimal y)[] point)
    {
        Coordinates = point.Select(p => new[] {p.x, p.y}).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(LineString));
    }

    public MultiPoint(IEnumerable<Point> points)
    {
        Coordinates = points.Select(point => new[] {point.X, point.Y}).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(MultiPoint));
    }

    public bool Equals(MultiPoint? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiPoint multiPoint && Equals(multiPoint);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiPoint? left, MultiPoint? right)
        => Equals(left, right);

    public static bool operator !=(MultiPoint? left, MultiPoint? right)
        => !Equals(left, right);
}

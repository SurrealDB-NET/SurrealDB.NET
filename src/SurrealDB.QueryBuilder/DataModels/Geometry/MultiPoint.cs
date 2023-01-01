namespace SurrealDB.QueryBuilder.DataModels.Geometry;

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
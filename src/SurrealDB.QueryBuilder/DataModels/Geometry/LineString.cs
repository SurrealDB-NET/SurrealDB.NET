namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public class LineString : Object, IGeometry, IEquatable<LineString>
{
    public decimal[][] Coordinates { get; }

    public LineString(params (decimal x, decimal y)[] point)
    {
        Coordinates = point.Select(p => new[] { p.x, p.y }).ToArray();
        
        Add("coordinates", Coordinates);
        Add("type", nameof(LineString));
    }

    public LineString(IEnumerable<Point> points)
    {
        Coordinates = points.Select(point => new[] {point.X, point.Y}).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(LineString));
    }

    public bool Equals(LineString? other)
        => other is not null && Coordinates.SequenceEqual(other.Coordinates);

    public override bool Equals(object? obj)
        => obj is LineString lineString && Equals(lineString);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(LineString? left, LineString? right)
        => Equals(left, right);

    public static bool operator !=(LineString? left, LineString? right)
        => !Equals(left, right);
}

namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON point with a <see cref="X"/> and <see cref="Y"/>. It is equivalent to SurrealDB's Point data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#point"/>
/// </summary>
public class Point : Object, IGeometry, IEquatable<Point>
{
    public decimal X { get; }

    public decimal Y { get; }

    public Point(decimal x, decimal y)
    {
        X = x;
        Y = y;

        Add("coordinates", new[] {x, y});
        Add("type", nameof(Point));
    }

    public static implicit operator Point((decimal longitude, decimal latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    public bool Equals(Point? other)
        => other is not null && X == other.X && Y == other.Y;

    public override bool Equals(object? other)
        => other is Point point && Equals(point);

    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    public static bool operator ==(Point left, Point right)
        => Equals(left, right);

    public static bool operator !=(Point left, Point right)
        => !Equals(left, right);
}

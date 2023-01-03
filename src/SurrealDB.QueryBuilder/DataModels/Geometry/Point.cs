namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON point with a <see cref="X"/> and <see cref="Y"/>. It is equivalent to SurrealDB's Point data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#point"/>
/// </summary>
public readonly struct Point : IGeometry, IEquatable<Point>
{
    public readonly decimal X { get; }

    public readonly decimal Y { get; }

    public Point(decimal x, decimal y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out decimal x, out decimal y)
    {
        x = X;
        y = Y;
    }

    public static implicit operator Point((decimal longitude, decimal latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    public static implicit operator (decimal x, decimal y)(Point point)
        => (point.X, point.Y);

    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(Point) }, { "coordinates", CoordinatesOnly() } };

    internal decimal[] CoordinatesOnly()
        => new[] { X, Y };

    public bool Equals(Point value)
        => X == value.X && Y == value.Y;

    public override bool Equals(object? value)
        => value is Point point && Equals(point);

    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    public static bool operator ==(Point left, Point right)
        => Equals(left, right);

    public static bool operator !=(Point left, Point right)
        => !Equals(left, right);
}

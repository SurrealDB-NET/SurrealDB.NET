namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON point with a <see cref="X"/> and <see cref="Y"/>. It is equivalent to SurrealDB's Point data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#point"/>
/// </summary>
public readonly struct Point : IGeometry, IEquatable<Point>
{
    public readonly double X { get; }

    public readonly double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out double x, out double y)
    {
        x = X;
        y = Y;
    }

    public static implicit operator Point((double longitude, double latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    public static implicit operator (double x, double y)(Point point)
        => (point.X, point.Y);

    /// <inheritdoc/>
    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(Point) }, { "coordinates", CoordinatesOnly() } };

    internal double[] CoordinatesOnly()
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

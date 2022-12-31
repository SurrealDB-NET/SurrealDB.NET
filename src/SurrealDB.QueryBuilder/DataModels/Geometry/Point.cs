namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// A class that represents a geolocation point with latitude and longitude. It is equivalent to SurrealDB's Point object.
/// </summary>
public struct Point : IEquatable<Point>
{
    private const string _type = "Point";

    public decimal[] Coordinates { get; set; }

    public Point()
        => Coordinates = new[] {0m, 0m};

    public Point(decimal longitude, decimal latitude)
        => Coordinates = new[] {longitude, latitude};

    public static implicit operator Point((decimal longitude, decimal latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    public bool Equals(Point other)
        => Coordinates.SequenceEqual(other.Coordinates);

    public override bool Equals(object? other)
        => other is Point point && Equals(point);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public override string ToString()
        => $$"""
        {
          type: {{_type}},
          coordinates: [
            {{Coordinates[0]}},
            {{Coordinates[1]}}
          ]
        }
        """;

    public static bool operator ==(Point left, Point right)
        => left.Equals(right);

    public static bool operator !=(Point left, Point right)
        => !left.Equals(right);
}

internal static class PointExtensions
{
    internal static string CoordinatesToString(this Point point)
        => $$"""
            [{{point.Coordinates[0]}}, {{point.Coordinates[1]}}]
        """;
}
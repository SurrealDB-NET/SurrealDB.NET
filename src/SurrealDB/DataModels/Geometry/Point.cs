namespace SurrealDB.DataModels;

public readonly struct Point : IEquatable<Point>
{
    private const string _type = nameof(Point);

    public readonly decimal[] Coordinates { get; init; }

    public Point()
        => Coordinates = new decimal[2] { 0m, 0m };

    public Point(decimal longitude, decimal latitude)
        => Coordinates = new decimal[2] { longitude, latitude };

    public static implicit operator Point((decimal longitude, decimal latitude) coordinates)
        => new Point(coordinates.longitude, coordinates.latitude);

    public bool Equals(Point other)
        => Coordinates.SequenceEqual(other.Coordinates);

    public override bool Equals(object? other)
        => other is Point point
        && Equals(point);

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
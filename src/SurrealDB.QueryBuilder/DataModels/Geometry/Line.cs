namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class Line : IGeometry, IEquatable<Line>
{
    private const string _type = "LineString";

    public Point[] Coordinates { get; set; }

    public Line(Point[] coordinates)
        => Coordinates = coordinates;

    public Line(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(Line? other)
      => other is Line
      && Coordinates.SequenceEqual(other.Coordinates);

    public override bool Equals(object? obj)
      => Equals(obj as Line);

    public override int GetHashCode()
      => HashCode.Combine(Coordinates);

    public static bool operator ==(Line? left, Line? right)
      => Equals(left, right);

    public static bool operator !=(Line? left, Line? right)
      => !Equals(left, right);

    public override string ToString()
        => $$"""
        {
          type: ""{{_type}}"",
          coordinates: [
        {{string.Join(",\n", Coordinates.Select(p => p.DisplayCoordinates()))}}
          ]
        }
        """;
}
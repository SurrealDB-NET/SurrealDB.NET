namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class Line : IGeometry, IEquatable<Line>
{
    public Point[] Coordinates { get; set; }

    public Line(Point[] coordinates)
        => Coordinates = coordinates;

    public Line(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(Line? value)
      => value is Line
      && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
      => Equals(value as Line);

    public override int GetHashCode()
      => HashCode.Combine(Coordinates);

    public static bool operator ==(Line? left, Line? right)
      => Equals(left, right);

    public static bool operator !=(Line? left, Line? right)
      => !Equals(left, right);
}
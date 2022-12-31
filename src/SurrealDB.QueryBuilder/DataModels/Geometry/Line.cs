namespace SurrealDB.DataModels.Geometry;

public sealed class Line : IGeometrical
{
    private const string _type = "LineString";

    public Point[] Coordinates { get; set; }

    public Line(Point[] coordinates)
        => Coordinates = coordinates;

    public override string ToString()
        => $$"""
        {
          type: {{_type}},
          coordinates: [
        {{string.Join(",\n", Coordinates.Select(p => p.CoordinatesToString()))}}
          ]
        }
        """;
}

internal static class LineExtensions
{
    internal static string CoordinatesToString(this Line line)
        => $$"""
            [ {{string.Join(", ", line.Coordinates.Select(p => $"[{p.Coordinates[0]}, {p.Coordinates[1]}]"))}} ]
        """;
}

public class Program
{
    public static void Main()
    {
        DateOnly date = new DateOnly(2021, 1, 1);
    }
}

namespace SurrealDB.DataModels.Geometry;

public sealed class Polygon : IGeometrical
{
    private const string _type = "Polygon";

    public Point[] Coordinates { get; set; }

    public Polygon(Point[] coordinates)
        => Coordinates = coordinates;

    public override string ToString()
        => $$"""
        {
          type: {{_type}},
          coordinates: [[
        {{string.Join(",\n", Coordinates.Select(p => p.CoordinatesToString()))}}
          ]]
        }
        """;
}
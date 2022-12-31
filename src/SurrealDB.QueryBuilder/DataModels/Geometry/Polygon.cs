namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class Polygon : IGeometry
{
    private const string _type = "Polygon";

    public Point[] Coordinates { get; set; }

    public Polygon(Point[] coordinates)
        => Coordinates = coordinates;

    public Polygon(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public override string ToString()
        => $$"""
        {
          type: "{{_type}}",
          coordinates: [[
        {{string.Join(",\n", Coordinates.Select(point => point.DisplayCoordinates()))}}
          ]]
        }
        """;
}
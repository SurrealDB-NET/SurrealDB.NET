namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class MultiPoint : IGeometry
{
    private const string _type = "MultiPoint";

    public Point[] Coordinates { get; set; }

    public MultiPoint(Point[] coordinates)
        => Coordinates = coordinates;

    public MultiPoint(IEnumerable<Point> coordinates)
        => Coordinates = coordinates.ToArray();

    public override string ToString()
        => $$"""
        {
          type: "{{_type}}",
          coordinates: [
        {{string.Join(",\n", Coordinates.Select(point => point.DisplayCoordinates()))}}
          ]
        }
        """;
}

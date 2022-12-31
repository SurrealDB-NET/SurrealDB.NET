namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class MultiPolygon : IGeometry
{
    private const string _type = "MultiPolygon";

    public Polygon[] Coordinates { get; set; }

    public MultiPolygon(Polygon[] coordinates)
        => Coordinates = coordinates;

    public MultiPolygon(IEnumerable<Polygon> coordinates)
        => Coordinates = coordinates.ToArray();

    public override string ToString()
        => $$"""
        {
          type: "{{_type}}",
          coordinates: [
        {{string.Join(",\n", Coordinates.Select(polygon => polygon.DisplayCoordinates()))}}
          ]
        }
        """;
}
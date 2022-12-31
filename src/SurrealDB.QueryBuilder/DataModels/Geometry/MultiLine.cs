namespace SurrealDB.DataModels.Geometry;

public sealed class MultiLine : IGeometrical
{
    private const string _type = "MultiLineString";

    public Line[] Coordinates { get; set; }

    public MultiLine(Line[] coordinates)
        => Coordinates = coordinates;

    public override string ToString()
        => $$"""
        {
          type: {{_type}},
          coordinates: [
        {{string.Join(",\n", Coordinates.Select(l => l.CoordinatesToString()))}}
          ]
        }
        """;
}

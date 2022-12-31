namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class MultiPoint : IGeometrical
{
    private const string _type = "MultiPoint";

    public Point[] Coordinates { get; set; }

    public MultiPoint(Point[] coordinates)
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

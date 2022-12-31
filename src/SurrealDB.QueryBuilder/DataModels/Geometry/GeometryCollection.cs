namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public sealed class GeometryCollection : IGeometry
{
    private const string _type = "GeometryCollection";

    public IGeometry[] Geometries { get; set; }

    public GeometryCollection(IGeometry[] geometries)
        => Geometries = geometries;

    public GeometryCollection(IEnumerable<IGeometry> geometries)
        => Geometries = geometries.ToArray();

    public override string ToString()
        => $$"""
        {
          type: "{{_type}}",
          geometries: [
        {{string.Join(",\n", Geometries.Select(geometry => $"    {geometry.ToString().Replace("\n", "\n    ")}"))}}
          ]
        }
        """;
}
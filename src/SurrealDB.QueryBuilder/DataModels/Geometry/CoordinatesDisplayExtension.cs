namespace SurrealDB.QueryBuilder.DataModels.Geometry;

internal static class GeometryDisplayExtension
{
    internal static string DisplayCoordinates(this Point point)
        => $$"""
            [{{point.Coordinates[0]}}, {{point.Coordinates[1]}}]
        """;

    internal static string DisplayCoordinates(this Line line)
        => $$"""
            [ {{string.Join(", ", line.Coordinates.Select(p => $"[{p.Coordinates[0]}, {p.Coordinates[1]}]"))}} ]
        """;

    internal static string DisplayCoordinates(this Polygon polygon)
        => $$"""
            [
              [ {{string.Join(", ", polygon.Coordinates.Select(p => $"[{p.Coordinates[0]}, {p.Coordinates[1]}]"))}} ]
            ]
        """;
}
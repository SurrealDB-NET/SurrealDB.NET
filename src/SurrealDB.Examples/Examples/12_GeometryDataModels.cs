namespace SurrealDB.Examples;

using SurrealDB.QueryBuilder.DataModels.Geometry;

public class GeometryDataModels : IExample
{
    public string Name => "Geometry Data Models";

    public string Description => "This example shows how to represent geometry data using the Geometry data models";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine(new Point(-0.118092, 51.509865).ToGeoJson());

        Console.WriteLine(new LineString((10, 11.2), (10.5, 11.9)).ToGeoJson());

        Console.WriteLine(new Polygon(
            (-0.38314819, 51.37692386), (0.1785278, 51.37692386),
            (0.1785278, 51.61460570), (-0.38314819, 51.61460570),
            (-0.38314819, 51.37692386))
            .ToGeoJson()
        );

        Console.WriteLine(new MultiPoint((10, 11.2), (10.5, 11.9)).ToGeoJson());

        Console.WriteLine(
            new MultiLineString(
                new((10, 11.2), (10.5, 11.9)),
                new((11, 12.2), (11.5, 12.9), (12, 13))
            ).ToGeoJson()
        );

        Console.WriteLine(
            new MultiPolygon(
                new((10, 11.2), (10.5, 11.9), (10.8, 12), (10, 11.2)),
                new((9, 11.2), (10.5, 11.9), (10.3, 13), (9, 11.2))
            ).ToGeoJson()
        );

        Console.WriteLine(
            new GeometryCollection(
                new MultiPoint((10, 11.2), (10.5, 11.9)),
                new Polygon(
                    (-0.38314819, 51.37692386), (0.1785278, 51.37692386),
                    (0.1785278, 51.61460570), (-0.38314819, 51.61460570),
                    (-0.38314819, 51.37692386)
                ),
                new MultiPolygon(
                    new((10, 11.2), (10.5, 11.9), (10.8, 12), (10, 11.2)),
                    new((9, 11.2), (10.5, 11.9), (10.3, 13), (9, 11.2))
                ),
                new GeometryCollection(
                    new Point(-0.118092, 51.509865),
                    new LineString((10, 11.2), (10.5, 11.9)),
                    new Polygon(
                        (-0.38314819, 51.37692386), (0.1785278, 51.37692386),
                        (0.1785278, 51.61460570), (-0.38314819, 51.61460570),
                        (-0.38314819, 51.37692386)
                    ),
                    new MultiPoint((10, 11.2), (10.5, 11.9)),
                    new MultiLineString(
                        new((10, 11.2), (10.5, 11.9)),
                        new((11, 12.2), (11.5, 12.9), (12, 13))
                    ),
                    new MultiPolygon(
                        new((10, 11.2), (10.5, 11.9), (10.8, 12), (10, 11.2)),
                        new((9, 11.2), (10.5, 11.9), (10.3, 13), (9, 11.2))
                    )
                )
            ).ToGeoJson()
        );

        await Task.CompletedTask;
    }
}

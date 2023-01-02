namespace SurrealDB.Examples;

using SurrealDB.QueryBuilder.DataModels.Geometry;

public class GeometryDataModels : IExample
{
    public string Name => "Geometry Data Models";

    public string Description => "This example shows how to represent geometry data using the Geometry data models";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine(new Point(1, 2));

        Console.WriteLine(new LineString((1, 2), (3, 4)));

        Console.WriteLine(new Polygon((1, 2), (3, 4), (5, 6), (7, 8), (9, 10), (1, 2)));

        Console.WriteLine(new MultiPoint((1, 2), (3, 4)));

        Console.WriteLine(
            new MultiLineString(
                new((1, 2), (3, 4)),
                new((5, 6), (7, 8))
            )
        );

        Console.WriteLine(
            new MultiPolygon(
                new Polygon((1, 2), (3, 4), (5, 6), (7, 8), (9, 10), (1, 2)),
                new Polygon((11, 12), (13, 14), (15, 16), (17, 18), (19, 20), (11, 12))
            )
        );

        Console.WriteLine(
            new GeometryCollection(
                new Point(1, 2),
                new LineString((1, 2), (3, 4)),
                new Polygon((1, 2), (3, 4), (5, 6), (1, 2)),
                new MultiPoint((1, 2), (3, 4)),
                new MultiLineString(
                    new((1, 2), (3, 4)),
                    new((5, 6), (7, 8))
                ),
                new MultiPolygon(
                    new((1, 2), (3, 4), (5, 6), (1, 2)),
                    new((11, 12), (13, 14), (15, 16), (11, 12))
                ),
                new MultiPoint((1, 2), (3, 4)),
                new MultiLineString(
                    new((1, 2), (3, 4)),
                    new((5, 6), (7, 8))
                ),
                new MultiPolygon(
                    new((1, 2), (3, 4), (5, 6), (7, 8), (1, 2)),
                    new((11, 12), (13, 14), (15, 16), (11, 12))
                ),
                new GeometryCollection(
                    new Point(1, 2),
                    new LineString((1, 2), (3, 4)),
                    new Polygon((1, 2), (3, 4), (5, 6), (7, 8))
                )
            )
        );

        await Task.CompletedTask;
    }
}

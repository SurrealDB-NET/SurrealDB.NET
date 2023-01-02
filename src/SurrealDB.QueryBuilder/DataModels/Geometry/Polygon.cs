namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON Polygon value for storing a geometric area. It is equivalent to SurrealDB's Polygon data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#polygon"/>
/// </summary>
public class Polygon : Object, IGeometry, IEquatable<Polygon>
{
    public decimal[][][] Coordinates { get; }

    public Polygon(params Point[] lines)
    {
        Coordinates = BuildPolygon(lines);

        Add("coordinates", Coordinates);
        Add("type", nameof(Polygon));
    }

    public Polygon(IEnumerable<Point> lines)
    {
        Coordinates = BuildPolygon(lines);

        Add("coordinates", Coordinates);
        Add("type", nameof(Polygon));
    }

    public bool Equals(Polygon? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is Polygon polygon && Equals(polygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(Polygon? left, Polygon? right)
        => Equals(left, right);

    public static bool operator !=(Polygon? left, Polygon? right)
        => !Equals(left, right);

    private static decimal[][][] BuildPolygon(IEnumerable<Point> points)
    {
        var pointsArray = points.ToArray();

        var coordinates = new decimal[1][][];

        coordinates[0] = new decimal[pointsArray.Length][];

        var i = 0;

        foreach (var point in pointsArray)
        {
            coordinates[0][i] = new decimal[2];
            coordinates[0][i][0] = point.X;
            coordinates[0][i][1] = point.Y;
            i++;
        }

        return coordinates;
    }
}

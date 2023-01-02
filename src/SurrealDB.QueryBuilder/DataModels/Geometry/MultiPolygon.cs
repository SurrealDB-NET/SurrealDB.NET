namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// A GeoJSON MultiPolygon value which contains multiple geometry polygons. It is equivalent to SurrealDB's MultiPolygon data type. <br/>
/// </summary>
public class MultiPolygon : Object, IGeometry, IEquatable<MultiPolygon>
{
    public decimal[][][][] Coordinates { get; }

    public MultiPolygon(params Polygon[] polygons)
    {
        Coordinates = polygons.Select(polygon => polygon.Coordinates).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(MultiPolygon));
    }

    public MultiPolygon(IEnumerable<Polygon> polygons)
    {
        Coordinates = polygons.Select(polygon => polygon.Coordinates).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(MultiPolygon));
    }

    public bool Equals(MultiPolygon? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiPolygon multiPolygon && Equals(multiPolygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiPolygon? left, MultiPolygon? right)
        => Equals(left, right);

    public static bool operator !=(MultiPolygon? left, MultiPolygon? right)
        => !Equals(left, right);
}

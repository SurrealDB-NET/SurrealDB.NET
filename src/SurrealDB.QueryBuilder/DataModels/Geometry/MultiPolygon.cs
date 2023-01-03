namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// A GeoJSON MultiPolygon value which contains multiple geometry polygons. It is equivalent to SurrealDB's MultiPolygon data type. <br/>
/// </summary>
public class MultiPolygon : IGeometry, IEquatable<MultiPolygon>
{
    public Polygon[] Coordinates { get; }

    public MultiPolygon(params Polygon[] polygons)
        => Coordinates = polygons;

    public MultiPolygon(IEnumerable<Polygon> polygons)
        => Coordinates = polygons.ToArray();

    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(MultiPolygon) }, { "coordinates", Coordinates } };

    public bool Equals(MultiPolygon? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => Equals(value as MultiPolygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);


    public static bool operator ==(MultiPolygon? left, MultiPolygon? right)
        => Equals(left, right);

    public static bool operator !=(MultiPolygon? left, MultiPolygon? right)
        => !Equals(left, right);
}

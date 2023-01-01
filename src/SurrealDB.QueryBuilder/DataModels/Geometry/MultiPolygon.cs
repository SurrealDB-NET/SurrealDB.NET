namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// A GeoJSON MultiPolygon value which contains multiple geometry polygons. It is equivalent to SurrealDB's MultiPolygon data type. <br/>
/// </summary>
public sealed class MultiPolygon : IGeometry, IEquatable<MultiPolygon>
{
    public Polygon[] Coordinates { get; set; }

    public MultiPolygon(Polygon[] coordinates)
        => Coordinates = coordinates;

    public MultiPolygon(IEnumerable<Polygon> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(MultiPolygon? value)
        => value is MultiPolygon
        && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiPolygon multiPolygon
        && Equals(multiPolygon);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiPolygon? left, MultiPolygon? right)
        => Equals(left, right);

    public static bool operator !=(MultiPolygon? left, MultiPolygon? right)
        => !Equals(left, right);
}
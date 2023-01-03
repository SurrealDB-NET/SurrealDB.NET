namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiLineString value which contains multiple geometry lines. It is equivalent to SurrealDB's MultiLine data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multilinestring"/>
/// </summary>
public class MultiLineString : IGeometry, IEquatable<MultiLineString>
{
    public LineString[] Coordinates { get; }

    public MultiLineString(params LineString[] lines)
        => Coordinates = lines;

    public MultiLineString(IEnumerable<LineString> lines)
        => Coordinates = lines.ToArray();

    /// <inheritdoc/>
    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(MultiLineString) }, { "coordinates", CoordinatesOnly() } };

    internal decimal[][][] CoordinatesOnly()
        => Coordinates.Select(line => line.CoordinatesOnly()).ToArray();

    public bool Equals(MultiLineString? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => Equals(value as MultiLineString);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiLineString? left, MultiLineString? right)
        => Equals(left, right);

    public static bool operator !=(MultiLineString? left, MultiLineString? right)
        => !Equals(left, right);
}

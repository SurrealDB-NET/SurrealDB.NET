namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiLineString value which contains multiple geometry lines. It is equivalent to SurrealDB's MultiLine data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multilinestring"/>
/// </summary>
public class MultiLineString : Object, IGeometry, IEquatable<MultiLineString>
{
    public decimal[][][] Coordinates { get; }

    public MultiLineString(params LineString[] lines)
    {
        Coordinates = lines.Select(line => line.Coordinates).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(MultiLineString));
    }

    public MultiLineString(IEnumerable<LineString> lines)
    {
        Coordinates = lines.Select(line => line.Coordinates).ToArray();

        Add("coordinates", Coordinates);
        Add("type", nameof(MultiLineString));
    }

    public bool Equals(MultiLineString? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiLineString multiLine && Equals(multiLine);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiLineString? left, MultiLineString? right)
        => Equals(left, right);

    public static bool operator !=(MultiLineString? left, MultiLineString? right)
        => !Equals(left, right);
}

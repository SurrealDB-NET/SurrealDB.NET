namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON MultiLineString value which contains multiple geometry lines. It is equivalent to SurrealDB's MultiLine data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multilinestring"/>
/// </summary>
public sealed class MultiLine : IGeometry, IEquatable<MultiLine>
{
    public Line[] Coordinates { get; set; }

    public MultiLine(Line[] coordinates)
        => Coordinates = coordinates;

    public MultiLine(IEnumerable<Line> coordinates)
        => Coordinates = coordinates.ToArray();

    public bool Equals(MultiLine? value)
        => value is MultiLine
        && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => value is MultiLine multiLine
        && Equals(multiLine);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    public static bool operator ==(MultiLine? left, MultiLine? right)
        => Equals(left, right);

    public static bool operator !=(MultiLine? left, MultiLine? right)
        => !Equals(left, right);
}
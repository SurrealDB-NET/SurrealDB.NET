namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GEOJson LineString value for storing a geometric path. It is equivalent to SurrealDB's LineString data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#line"/>
/// </summary>
public class LineString : IGeometry, IEquatable<LineString>
{
    public Point[] Coordinates { get; }

    public LineString(params Point[] points)
        => Coordinates = points;

    public LineString(IEnumerable<Point> points)
        => Coordinates = points.ToArray();

    /// <inheritdoc/>
    public SchemalessObject ToGeoJson()
            => new() { { "type", nameof(LineString) }, { "coordinates", CoordinatesOnly() } };

    public bool Equals(LineString? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    public override bool Equals(object? value)
        => Equals(value as LineString);

    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    internal double[][] CoordinatesOnly()
        => Coordinates.Select(point => point.CoordinatesOnly()).ToArray();

    public static bool operator ==(LineString? left, LineString? right)
        => Equals(left, right);

    public static bool operator !=(LineString? left, LineString? right)
        => !Equals(left, right);
}

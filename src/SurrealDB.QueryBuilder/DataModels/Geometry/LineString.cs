namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GEOJson LineString value for storing a geometric path. It is equivalent to SurrealDB's LineString data
///     type. <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#line" />
/// </summary>
public class LineString : IGeometry, IEquatable<LineString>
{
    /// <summary>
    ///     Gets the coordinates that define the path of this <see cref="LineString" />.
    /// </summary>
    /// <returns>The collection of <see cref="Point" /> that define the path of this <see cref="LineString" />.</returns>
    public Point[] Coordinates { get; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LineString" /> class with the specified coordinates.
    /// </summary>
    /// <param name="points">The collection of <see cref="Point" /> that define the path of this <see cref="LineString" />.</param>
    public LineString(params Point[] points)
        => Coordinates = points;

    /// <inheritdoc cref="LineString(Point[])" />
    public LineString(IEnumerable<Point> points)
        => Coordinates = points.ToArray();

    /// <summary>
    ///     Returns a value that indicates whether this instance is equal to a specified <see cref="LineString" />.
    /// </summary>
    /// <param name="value">A <see cref="LineString" /> to compare to this instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> has the same coordinates sequence as this instance;
    ///     otherwise, <see langword="false" />.
    /// </returns>
    public bool Equals(LineString? value)
        => value is not null && Coordinates.SequenceEqual(value.Coordinates);

    /// <inheritdoc />
    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(LineString) }, { "coordinates", CoordinatesOnly() } };

    /// <summary>
    ///     Returns a value that indicates whether this instance is equal to a specified <see cref="object" />.
    /// </summary>
    /// <param name="value">An <see cref="object" /> to compare to this instance.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="value" /> is a <see cref="LineString" /> and has the same
    ///     coordinates sequence as this instance; otherwise, <see langword="false" />.
    /// </returns>
    public override bool Equals(object? value)
        => Equals(value as LineString);

    /// <summary>
    ///     Returns the hash code for this <see cref="LineString" />.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code by combining the hash codes of the <see cref="Coordinates" />.</returns>
    public override int GetHashCode()
        => HashCode.Combine(Coordinates);

    /// <summary>
    ///     Returns the coordinates of this <see cref="LineString" /> as a 2D <see cref="double" /> array. Utilized by
    ///     <see cref="ToGeoJson" />.
    /// </summary>
    /// <returns>A 2D array of doubles representing the coordinates of this <see cref="LineString" />.</returns>
    internal double[][] CoordinatesOnly()
        => Coordinates.Select(point => point.CoordinatesOnly()).ToArray();

    /// <summary>
    ///     Returns a value that indicates whether two <see cref="LineString" /> instances are equal.
    /// </summary>
    /// <param name="left">A <see cref="LineString" /> to compare.</param>
    /// <param name="right">A <see cref="LineString" /> to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same coordinates
    ///     sequence; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator ==(LineString? left, LineString? right)
        => Equals(left, right);

    /// <summary>
    ///     Returns a value that indicates whether two <see cref="LineString" /> instances are not equal.
    /// </summary>
    /// <param name="left">A <see cref="LineString" /> to compare.</param>
    /// <param name="right">A <see cref="LineString" /> to compare.</param>
    /// <returns>
    ///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same
    ///     coordinates sequence; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator !=(LineString? left, LineString? right)
        => !Equals(left, right);
}

namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GeoJSON MultiPoint value which contains multiple geometry points. It is equivalent to SurrealDB's
///     MultiPoint data type. <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multipoint" />
/// </summary>
public class MultiPoint : IGeometry, IEquatable<MultiPoint>
{
	/// <summary>
	///     Gets the coordinates that define the points of this <see cref="MultiPoint" />.
	/// </summary>
	/// <value>The collection of <see cref="Point" />s that define the points of this <see cref="MultiPoint" />.</value>
	public Point[] Coordinates { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="MultiPoint" /> class with the specified coordinates.
	/// </summary>
	/// <param name="points">The coordinates that define this <see cref="MultiPoint" />.</param>
	public MultiPoint(params Point[] points)
		=> Coordinates = points;

	/// <inheritdoc cref="MultiPoint(Point[])" />
	public MultiPoint(IEnumerable<Point> points)
		=> Coordinates = points.ToArray();

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="MultiPoint" />.
	/// </summary>
	/// <param name="value">A <see cref="MultiPoint" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> has the same coordinates sequence as this instance;
	///     otherwise, <see langword="false" />.
	/// </returns>
	public bool Equals(MultiPoint? value)
		=> value is not null && Coordinates.SequenceEqual(value.Coordinates);

	/// <inheritdoc />
	public SchemalessObject ToGeoJson()
		=> new() { { "type", nameof(MultiPoint) }, { "coordinates", CoordinatesOnly() } };

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="object" />.
	/// </summary>
	/// <param name="value">An <see cref="object" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> is a <see cref="MultiPoint" /> and has the same
	///     coordinates sequence as this instance; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object? value)
		=> Equals(value as MultiPoint);

	/// <summary>
	///     Returns the hash code for this <see cref="MultiPoint" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code by combining the hash codes of the <see cref="Coordinates" />.</returns>
	public override int GetHashCode()
		=> HashCode.Combine(Coordinates);

	/// <summary>
	///     Returns the coordinates of this <see cref="MultiPoint" /> as a 2D <see cref="double" /> array. Utilized in
	///     <see cref="ToGeoJson" />.
	/// </summary>
	/// <returns>The coordinates of this <see cref="MultiPoint" /> as a 2D <see cref="double" /> array.</returns>
	internal double[][] CoordinatesOnly()
		=> Coordinates.Select(point => point.CoordinatesOnly()).ToArray();

	/// <summary>
	///     Returns a value indicating whether two specified <see cref="MultiPoint" /> instances are equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiPoint" /> to compare.</param>
	/// <param name="right">A <see cref="MultiPoint" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same coordinates
	///     sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator ==(MultiPoint? left, MultiPoint? right)
		=> Equals(left, right);

	/// <summary>
	///     Returns a value indicating whether two specified <see cref="MultiPoint" /> instances are not equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiPoint" /> to compare.</param>
	/// <param name="right">A <see cref="MultiPoint" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same
	///     coordinates sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(MultiPoint? left, MultiPoint? right)
		=> !Equals(left, right);
}

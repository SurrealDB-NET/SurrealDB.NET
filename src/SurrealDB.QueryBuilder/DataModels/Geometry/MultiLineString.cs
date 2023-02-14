namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GeoJSON MultiLineString value which contains multiple geometry lines. It is equivalent to SurrealDB's
///     MultiLine data type. <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#multilinestring" />
/// </summary>
public class MultiLineString : IGeometry, IEquatable<MultiLineString>
{
	/// <summary>
	///     Gets the collection of <see cref="LineString" /> that define the lines of this <see cref="MultiLineString" />.
	/// </summary>
	/// <returns>The collection of <see cref="LineString" /> that define the lines of this <see cref="MultiLineString" />.</returns>
	public LineString[] Coordinates { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="MultiLineString" /> class with the specified lines.
	/// </summary>
	/// <param name="lines">The lines that define this <see cref="MultiLineString" />.</param>
	public MultiLineString(params LineString[] lines)
	{
		Coordinates = lines;
	}

	/// <inheritdoc cref="MultiLineString(LineString[])" />
	public MultiLineString(IEnumerable<LineString> lines)
	{
		Coordinates = lines.ToArray();
	}

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="MultiLineString" />.
	/// </summary>
	/// <param name="value">A <see cref="MultiLineString" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> has the same lines sequence as this instance; otherwise,
	///     <see langword="false" />.
	/// </returns>
	public bool Equals(MultiLineString? value)
	{
		return value is not null && Coordinates.SequenceEqual(value.Coordinates);
	}

	/// <inheritdoc />
	public SchemalessObject ToGeoJson()
	{
		return new SchemalessObject
		{
			{ "type", nameof(MultiLineString) },
			{ "coordinates", CoordinatesOnly() }
		};
	}

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="object" />.
	/// </summary>
	/// <param name="value">An <see cref="object" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> is a <see cref="MultiLineString" /> and has the same
	///     lines sequence as this instance; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object? value)
	{
		return Equals(value as MultiLineString);
	}

	/// <summary>
	///     Returns the hash code for this <see cref="MultiLineString" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code by combining the hash codes of <see cref="Coordinates" />.</returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(Coordinates);
	}

	/// <summary>
	///     Returns the coordinates of this <see cref="MultiLineString" /> as a 3D <see cref="double" /> array. Utilized by
	///     <see cref="ToGeoJson" />.
	/// </summary>
	/// <returns>The coordinates of this <see cref="MultiLineString" /> as a 3D <see cref="double" /> array.</returns>
	internal double[][][] CoordinatesOnly()
	{
		return Coordinates.Select(line => line.CoordinatesOnly()).ToArray();
	}

	/// <summary>
	///     Returns a value indicating whether two <see cref="MultiLineString" /> instances are equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiLineString" /> to compare.</param>
	/// <param name="right">A <see cref="MultiLineString" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same lines
	///     sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator ==(MultiLineString? left, MultiLineString? right)
	{
		return Equals(left, right);
	}

	/// <summary>
	///     Returns a value indicating whether two <see cref="MultiLineString" /> instances are not equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiLineString" /> to compare.</param>
	/// <param name="right">A <see cref="MultiLineString" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same lines
	///     sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(MultiLineString? left, MultiLineString? right)
	{
		return !Equals(left, right);
	}
}

namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     A GeoJSON MultiPolygon value which contains multiple geometry polygons. It is equivalent to SurrealDB's
///     MultiPolygon data type. <br />
/// </summary>
public class MultiPolygon : IGeometry, IEquatable<MultiPolygon>
{
	/// <summary>
	///     Gets the collection of <see cref="Polygon" /> that define the polygons of this <see cref="MultiPolygon" />.
	/// </summary>
	/// <value>The collection of <see cref="Polygon" /> that define the polygons of this <see cref="MultiPolygon" />.</value>
	public Polygon[] Coordinates { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="MultiPolygon" /> class with the specified polygons.
	/// </summary>
	/// <param name="polygons">The polygons that define this <see cref="MultiPolygon" />.</param>
	public MultiPolygon(params Polygon[] polygons)
	{
		Coordinates = polygons;
	}

	/// <inheritdoc cref="MultiPolygon(Polygon[])" />
	public MultiPolygon(IEnumerable<Polygon> polygons)
	{
		Coordinates = polygons.ToArray();
	}

	/// <summary>
	///     Returns a value that indicates whether this instance is equal to a specified <see cref="MultiPolygon" />.
	/// </summary>
	/// <param name="value">A <see cref="MultiPolygon" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> has the same polygons sequence as this instance;
	///     otherwise, <see langword="false" />.
	/// </returns>
	public bool Equals(MultiPolygon? value)
	{
		return value is not null && Coordinates.SequenceEqual(value.Coordinates);
	}

	/// <inheritdoc />
	public SchemalessObject ToGeoJson()
	{
		return new SchemalessObject
		{
			{ "type", nameof(MultiPolygon) },
			{ "coordinates", CoordinatesOnly() }
		};
	}

	/// <summary>
	///     Returns a value that indicates whether this instance is equal to a specified <see cref="object" />.
	/// </summary>
	/// <param name="value">An <see cref="object" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> is a <see cref="MultiPolygon" /> and has the same
	///     polygons sequence as this instance; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object? value)
	{
		return Equals(value as MultiPolygon);
	}

	/// <summary>
	///     Returns the hash code for this <see cref="MultiPolygon" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code by combining the hash codes of <see cref="Coordinates" />.</returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(Coordinates);
	}

	/// <summary>
	///     Returns the coordinates of this <see cref="MultiPolygon" /> as a 4D <see cref="double" /> array. Utilized by
	///     <see cref="ToGeoJson" />.
	/// </summary>
	/// <returns>The coordinates of this <see cref="MultiPolygon" /> as a 4D <see cref="double" /> array.</returns>
	internal double[][][][] CoordinatesOnly()
	{
		return Coordinates.Select(polygon => polygon.CoordinatesOnly()).ToArray();
	}

	/// <summary>
	///     Determines whether two specified <see cref="MultiPolygon" /> instances are equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiPolygon" /> to compare.</param>
	/// <param name="right">A <see cref="MultiPolygon" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same polygons
	///     sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator ==(MultiPolygon? left, MultiPolygon? right)
	{
		return Equals(left, right);
	}

	/// <summary>
	///     Determines whether two specified <see cref="MultiPolygon" /> instances are not equal.
	/// </summary>
	/// <param name="left">A <see cref="MultiPolygon" /> to compare.</param>
	/// <param name="right">A <see cref="MultiPolygon" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same
	///     polygons sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(MultiPolygon? left, MultiPolygon? right)
	{
		return !Equals(left, right);
	}
}

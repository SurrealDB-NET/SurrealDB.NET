namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GeoJSON Polygon value for storing a geometric area. It is equivalent to SurrealDB's Polygon data type.
///     <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#polygon" />
/// </summary>
public class Polygon : IGeometry, IEquatable<Polygon>
{
	/// <summary>
	///     Gets the coordinates that define the perimeter of this <see cref="Polygon" />.
	/// </summary>
	/// <returns>The collection of <see cref="Point" /> that define the perimeter of this <see cref="Polygon" />.</returns>
	public Point[] Coordinates { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="Polygon" /> class with the specified coordinates.
	/// </summary>
	/// <param name="points">The collection of <see cref="Point" /> that define the perimeter of this <see cref="Polygon" />.</param>
	public Polygon(params Point[] points)
	{
		Coordinates = points;
	}

	/// <inheritdoc cref="Polygon(Point[])" />
	public Polygon(IEnumerable<Point> points)
	{
		Coordinates = points.ToArray();
	}

	/// <summary>
	///     Returns a value indicating wether this instance is equal to a specified <see cref="Polygon" />.
	/// </summary>
	/// <param name="value">A <see cref="Polygon" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> has the same coordinates sequence as this instance;
	///     otherwise, <see langword="false" />.
	/// </returns>
	public bool Equals(Polygon? value)
	{
		return value is not null && Coordinates.SequenceEqual(value.Coordinates);
	}

	/// <inheritdoc />
	public SchemalessObject ToGeoJson()
	{
		return new SchemalessObject
		{
			{ "type", nameof(Polygon) },
			{ "coordinates", CoordinatesOnly() }
		};
	}

	/// <summary>
	///     Returns a value indicating wether this instance is equal to a specified <see cref="object" />.
	/// </summary>
	/// <param name="value">An <see cref="object" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> is a <see cref="Polygon" /> and has the same coordinates
	///     sequence as this instance; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object? value)
	{
		return Equals(value as Polygon);
	}

	/// <summary>
	///     Returns the hash code for this <see cref="Polygon" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code by combining the hash codes of the <see cref="Coordinates" />.</returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(Coordinates);
	}

	/// <summary>
	///     Returns the coordinates of this <see cref="Polygon" /> as a 3D <see cref="double" /> array. Utilized by
	///     <see cref="ToGeoJson" />.
	/// </summary>
	/// <returns>The coordinates of this <see cref="Polygon" /> as a 3D <see cref="double" /> array.</returns>
	internal double[][][] CoordinatesOnly()
	{
		return new[] { Coordinates.Select(point => point.CoordinatesOnly()).ToArray() };
	}

	/// <summary>
	///     Returns a value indicating whether two <see cref="Polygon" /> instances are equal.
	///     <param name="left">A <see cref="Polygon" /> to compare.</param>
	///     <param name="right">A <see cref="Polygon" /> to compare.</param>
	///     <returns>
	///         <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same
	///         coordinates sequence; otherwise, <see langword="false" />.
	///     </returns>
	public static bool operator ==(Polygon? left, Polygon? right)
	{
		return Equals(left, right);
	}

	/// <summary>
	///     Returns a value indicating whether two <see cref="Polygon" /> instances are not equal.
	/// </summary>
	/// <param name="left">A <see cref="Polygon" /> to compare.</param>
	/// <param name="right">A <see cref="Polygon" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same
	///     coordinates sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(Polygon? left, Polygon? right)
	{
		return !Equals(left, right);
	}
}

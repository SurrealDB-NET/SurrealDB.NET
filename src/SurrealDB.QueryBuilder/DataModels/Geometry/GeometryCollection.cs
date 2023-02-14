namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GeoJSON GeometryCollection value which contains multiple different geometry types. It is equivalent to
///     SurrealDB's Collection data type. <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#collection" />
/// </summary>
public class GeometryCollection : IGeometry, IEquatable<GeometryCollection>
{
	/// <summary>
	///     Gets the collection of <see cref="IGeometry" />s that define the geometries of this
	///     <see cref="GeometryCollection" />.
	/// </summary>
	/// <value>
	///     The collection of <see cref="IGeometry" />s that define the geometries of this <see cref="GeometryCollection" />
	///     .
	/// </value>
	public IGeometry[] Geometries { get; }

	/// <summary>
	///     Initializes a new instance of the <see cref="GeometryCollection" /> class with the specified geometries.
	/// </summary>
	/// <param name="geometries">The geometries that define this <see cref="GeometryCollection" />.</param>
	public GeometryCollection(params IGeometry[] geometries)
	{
		Geometries = geometries;
	}

	/// <inheritdoc cref="GeometryCollection(IGeometry[])" />
	public GeometryCollection(IEnumerable<IGeometry> geometries)
	{
		Geometries = geometries.ToArray();
	}

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="GeometryCollection" />.
	/// </summary>
	/// <param name="value">A <see cref="GeometryCollection" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> has the same geometries sequence as this instance;
	///     otherwise, <see langword="false" />.
	/// </returns>
	public bool Equals(GeometryCollection? value)
	{
		return value is not null && Geometries.SequenceEqual(value.Geometries);
	}

	/// <inheritdoc />
	public SchemalessObject ToGeoJson()
	{
		return new SchemalessObject
		{
			{ "type", nameof(GeometryCollection) },
			{ "geometries", Geometries }
		};
	}

	/// <summary>
	///     Returns a value indicating whether this instance is equal to a specified <see cref="object" />.
	/// </summary>
	/// <param name="value">An <see cref="object" /> to compare to this instance.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="value" /> is a <see cref="GeometryCollection" /> and has the same
	///     geometries sequence as this instance; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object? value)
	{
		return Equals(value as GeometryCollection);
	}

	/// <summary>
	///     Returns the hash code for this <see cref="GeometryCollection" />.
	/// </summary>
	/// <returns>A 32-bit signed integer hash code by combining the hash codes of <see cref="Geometries" />.</returns>
	public override int GetHashCode()
	{
		return HashCode.Combine(Geometries);
	}

	/// <summary>
	///     Returns a value indicating whether two specified <see cref="GeometryCollection" /> instances are equal.
	/// </summary>
	/// <param name="left">A <see cref="GeometryCollection" /> to compare.</param>
	/// <param name="right">A <see cref="GeometryCollection" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> have the same geometries
	///     sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator ==(GeometryCollection? left, GeometryCollection? right)
	{
		return Equals(left, right);
	}

	/// <summary>
	///     Returns a value indicating whether two specified <see cref="GeometryCollection" /> instances are not equal.
	/// </summary>
	/// <param name="left">A <see cref="GeometryCollection" /> to compare.</param>
	/// <param name="right">A <see cref="GeometryCollection" /> to compare.</param>
	/// <returns>
	///     <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> do not have the same
	///     geometries sequence; otherwise, <see langword="false" />.
	/// </returns>
	public static bool operator !=(GeometryCollection? left, GeometryCollection? right)
	{
		return !Equals(left, right);
	}
}

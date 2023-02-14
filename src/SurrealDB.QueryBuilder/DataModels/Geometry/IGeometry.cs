namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
///     Represents a GeoJSON geometry object. It is equivalent to SurrealDB's Geometry data type. <br />
///     <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries" />
/// </summary>
public interface IGeometry
{
	/// <summary>
	///     Converts this geometry instance to GeoJSON represented as a <see cref="SchemalessObject" />.
	/// </summary>
	/// <returns>A <see cref="SchemalessObject" /> representing the GeoJSON of this geometry instance.</returns>
	public SchemalessObject ToGeoJson();
}

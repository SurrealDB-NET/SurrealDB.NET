namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON GeometryCollection value which contains multiple different geometry types. It is equivalent to SurrealDB's Collection data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#collection"/>
/// </summary>
public sealed class GeometryCollection : IGeometry, IEquatable<GeometryCollection>
{
    public IGeometry[] Geometries { get; set; }

    public GeometryCollection(IGeometry[] geometries)
        => Geometries = geometries;

    public GeometryCollection(IEnumerable<IGeometry> geometries)
        => Geometries = geometries.ToArray();

    public bool Equals(GeometryCollection? value)
        => value is GeometryCollection
        && Geometries.SequenceEqual(value.Geometries);

    public override bool Equals(object? value)
        => value is GeometryCollection geometryCollection
        && Equals(geometryCollection);

    public override int GetHashCode()
        => HashCode.Combine(Geometries);

    public static bool operator ==(GeometryCollection? left, GeometryCollection? right)
        => Equals(left, right);

    public static bool operator !=(GeometryCollection? left, GeometryCollection? right)
        => !Equals(left, right);
}
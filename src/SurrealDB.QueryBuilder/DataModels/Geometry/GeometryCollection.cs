namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON GeometryCollection value which contains multiple different geometry types. It is equivalent to SurrealDB's Collection data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#collection"/>
/// </summary>
public class GeometryCollection : IGeometry, IEquatable<GeometryCollection>
{
    public IGeometry[] Geometries { get; }

    public GeometryCollection(params IGeometry[] geometries)
        => Geometries = geometries;

    public GeometryCollection(IEnumerable<IGeometry> geometries)
        => Geometries = geometries.ToArray();

    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(GeometryCollection) }, { "geometries", Geometries } };

    public bool Equals(GeometryCollection? value)
        => value is not null && Geometries.SequenceEqual(value.Geometries);

    public override bool Equals(object? value)
        => Equals(value as GeometryCollection);

    public override int GetHashCode()
        => HashCode.Combine(Geometries);

    public static bool operator ==(GeometryCollection? left, GeometryCollection? right)
        => Equals(left, right);

    public static bool operator !=(GeometryCollection? left, GeometryCollection? right)
        => !Equals(left, right);
}

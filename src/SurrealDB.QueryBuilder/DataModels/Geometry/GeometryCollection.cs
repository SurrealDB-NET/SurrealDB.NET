namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON GeometryCollection value which contains multiple different geometry types. It is equivalent to SurrealDB's Collection data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#collection"/>
/// </summary>
public class GeometryCollection : Object, IGeometry, IEquatable<GeometryCollection>
{
    public IGeometry[] Geometries { get; }

    public GeometryCollection(params IGeometry[] geometries)
    {
        Geometries = geometries;

        Add("geometries", Geometries);
        Add("type", nameof(GeometryCollection));
    }

    public GeometryCollection(IEnumerable<IGeometry> geometries)
    {
        Geometries = geometries.ToArray();

        Add("geometries", Geometries);
        Add("type", nameof(GeometryCollection));
    }

    public bool Equals(GeometryCollection? value)
        => value is not null && Geometries.SequenceEqual(value.Geometries);

    public override bool Equals(object? value)
        => value is GeometryCollection collection && Equals(collection);

    public override int GetHashCode()
        => HashCode.Combine(Geometries);

    public static bool operator ==(GeometryCollection? left, GeometryCollection? right)
        => Equals(left, right);

    public static bool operator !=(GeometryCollection? left, GeometryCollection? right)
        => !Equals(left, right);
}

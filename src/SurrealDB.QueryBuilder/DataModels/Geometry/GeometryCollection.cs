namespace SurrealDB.QueryBuilder.DataModels.Geometry;

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
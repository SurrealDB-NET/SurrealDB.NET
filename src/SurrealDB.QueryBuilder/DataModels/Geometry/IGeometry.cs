namespace SurrealDB.QueryBuilder.DataModels.Geometry;

public interface IGeometry
{
    SchemalessObject ToGeoJson();
}

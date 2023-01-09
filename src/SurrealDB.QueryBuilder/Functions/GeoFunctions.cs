using SurrealDB.QueryBuilder.Attributes;
using SurrealDB.QueryBuilder.DataModels.Geometry;
using SurrealDB.QueryBuilder.Exceptions;

namespace SurrealDB.QueryBuilder.Functions;

using DataModels.Geometry;

public static class GeoFunctions
{
    [SurrealFunction("geo::area({0})")]
    public static decimal Area(IGeometry geometry)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::bearing({0},{1})")]
    public static decimal Bearing(Point point1, Point point2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::centroid({0})")]
    public static Point? Centroid(IGeometry geometry)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::distance({0},{1})")]
    public static decimal Distance(Point point1, Point point2)
        => throw new IllegalSurrealFunctionCallException();

    public static class Hash
    {
        [SurrealFunction("geo::hash::decode({0})")]
        public static string Decode(Point point)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("geo::hash::encode({0},{1})")]
        public static string Encode(Point point)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("geo::hash::encode({0},{1})")]
        public static string Encode(Point point, uint accuracy)
            => throw new IllegalSurrealFunctionCallException();
    }
}

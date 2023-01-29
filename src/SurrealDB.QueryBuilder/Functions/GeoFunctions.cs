namespace SurrealDB.QueryBuilder.Functions;

using Attributes;
using DataModels.Geometry;
using Exceptions;

public static class GeoFunctions
{
    [SurrealFunction("geo::area")]
    public static decimal Area(IGeometry geometry)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::bearing")]
    public static decimal Bearing(Point point1, Point point2)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::centroid")]
    public static Point? Centroid(IGeometry geometry)
        => throw new IllegalSurrealFunctionCallException();

    [SurrealFunction("geo::distance")]
    public static decimal Distance(Point point1, Point point2)
        => throw new IllegalSurrealFunctionCallException();

    public static class Hash
    {
        [SurrealFunction("geo::hash::decode")]
        public static string Decode(Point point)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("geo::hash::encode")]
        public static string Encode(Point point)
            => throw new IllegalSurrealFunctionCallException();

        [SurrealFunction("geo::hash::encode")]
        public static string Encode(Point point, uint accuracy)
            => throw new IllegalSurrealFunctionCallException();
    }
}

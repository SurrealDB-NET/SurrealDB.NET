namespace SurrealDB.QueryBuilder.Functions;

using DataModels.Geometry;

public static class GeoFunctions
{
    public static Function Area(IGeometry geometry)
        => new($"geo::area({geometry})");

    public static Function Bearing(Point point1, Point point2)
        => new($"geo::bearing({point1}, {point2})");

    public static Function Centroid(IGeometry geometry)
        => new($"geo::centroid({geometry})");

    public static Function Distance(Point point1, Point point2)
        => new($"geo::distance({point1}, {point2})");

    public static class Hash
    {
        public static Function Decode(Point point)
            => new($"geo::hash::decode({point})");

        public static Function Encode(Point point)
            => new($"geo::hash::encode({point})");
    }
}

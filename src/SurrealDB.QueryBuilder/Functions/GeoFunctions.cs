using SurrealDB.QueryBuilder.DataModels.Geometry;

namespace SurrealDB.QueryBuilder.Functions;

public static class GeoFunctions
{
    public static string Area(IGeometry geometry)
        => $"geo::area({geometry})";

    public static string Bearing(Point point1, Point point2)
        => $"geo::bearing({point1}, {point2})";

    public static string Centroid(IGeometry geometry)
        => $"geo::centroid({geometry})";

    public static string Distance(Point point1, Point point2)
        => $"geo::distance({point1}, {point2})";

    public static class Hash
    {
        public static string Decode(Point point)
            => $"geo::hash::decode({point})";

        public static string Encode(Point point)
            => $"geo::hash::encode({point})";
    }
}

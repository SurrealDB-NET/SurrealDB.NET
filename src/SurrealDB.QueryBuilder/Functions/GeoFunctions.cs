namespace SurrealDB.QueryBuilder.Functions;

public static class GeoFunctions
{
    public static string Area(string type, int[,,] coordinates) => throw new NotImplementedException();
    public static string Bearing(int[][] x, int[][] y) => throw new NotImplementedException();
    public static string Centroid(string type, int[,,] coordinates) => throw new NotImplementedException();
    public static string Distance(int[][] x, int[][] y) => throw new NotImplementedException();

    public static class Hash
    {
        public static string Decode(string hash) => $"geo::hash::decode({hash})";
        public static string Encode(int[][] point, int accuracy) => throw new NotImplementedException();
    }
}


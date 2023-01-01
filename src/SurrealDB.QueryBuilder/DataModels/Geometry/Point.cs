using System.Diagnostics.CodeAnalysis;

namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON point with a <see cref="Longitude"/> and <see cref="Latitude"/>. It is equivalent to SurrealDB's Point data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#point"/>
/// </summary>
public struct Point : IGeometry, IEquatable<Point>
{
    public readonly decimal Longitude { get; init; }

    public readonly decimal Latitude { get; init; }

    public Point()
        => (Longitude, Latitude) = (0, 0);

    public Point(decimal longitude, decimal latitude)
        => (Longitude, Latitude) = (longitude, latitude);

    public static implicit operator Point((decimal longitude, decimal latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    public bool Equals(Point value)
        => Longitude == value.Longitude
        && Latitude == value.Latitude;

    public override bool Equals([NotNullWhen(true)] object? value)
        => value is Point point
        && Equals(point);

    public override int GetHashCode()
        => HashCode.Combine(Longitude, Latitude);

    public static bool operator ==(Point left, Point right)
        => Equals(left, right);

    public static bool operator !=(Point left, Point right)
        => !Equals(left, right);
}
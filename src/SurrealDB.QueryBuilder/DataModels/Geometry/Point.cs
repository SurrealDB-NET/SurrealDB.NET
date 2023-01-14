namespace SurrealDB.QueryBuilder.DataModels.Geometry;

/// <summary>
/// Represents a GeoJSON point with a <see cref="X"/> and <see cref="Y"/>. It is equivalent to SurrealDB's Point data type. <br/>
/// <see href="https://surrealdb.com/docs/surrealql/datamodel/geometries#point"/>
/// </summary>
public readonly struct Point : IGeometry, IEquatable<Point>
{
    /// <summary>
    /// Gets the X coordinate of this <see cref="Point"/> structure, representing the longitude.
    /// </summary>
    /// <returns>The X coordinate of this <see cref="Point"/> structure, representing the longitude.</returns>
    public readonly double X { get; }

    /// <summary>
    /// Gers the Y coordinate of this <see cref="Point"/> structure, representing the latitude.
    /// </summary>
    /// <returns>The Y coordinate of this <see cref="Point"/> structure, representing the latitude.</returns>
    public readonly double Y { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> structure with the specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate (longitude).</param>
    /// <param name="y">The Y coordinate (latitude).</param>
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Deconstructs this <see cref="Point"/> into its <see cref="X"/> and <see cref="Y"/> components.
    /// </summary>
    /// <param name="x">The X coordinate (longitude).</param>
    /// <param name="y">The Y coordinate (latitude).</param>
    public void Deconstruct(out double x, out double y)
    {
        x = X;
        y = Y;
    }

    /// <summary>
    /// Implicitly converts a tuple containg a longitude and latitude value to a <see cref="Point"/> structure.
    /// </summary>
    /// <param name="coordinates">The tuple containing the longitude and latitude values respectively.</param>
    public static implicit operator Point((double longitude, double latitude) coordinates)
        => new(coordinates.longitude, coordinates.latitude);

    /// <summary>
    /// Implicitly converts a <see cref="Point"/> structure to a tuple containing a longitude and latitude value.
    /// </summary>
    /// <param name="point">The <see cref="Point"/> structure to convert from.</param>
    public static implicit operator (double x, double y)(Point point)
        => (point.X, point.Y);

    /// <inheritdoc/>
    public SchemalessObject ToGeoJson()
        => new() { { "type", nameof(Point) }, { "coordinates", CoordinatesOnly() } };

    /// <summary>
    /// Returns an array containing the <see cref="X"/> and <see cref="Y"/> coordinates of this <see cref="Point"/>.
    /// </summary>
    /// <returns>An array containing the <see cref="X"/> and <see cref="Y"/> coordinates of this <see cref="Point"/>.</returns>
    internal double[] CoordinatesOnly()
        => new[] { X, Y };

    /// <summary>
    /// Returns a value that indicates whether this instance is equal to a specified <see cref="Point"/>.
    /// </summary>
    /// <param name="value">The <see cref="Point"/> to compare to this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> has the same <see cref="X"/> and <see cref="Y"/> as this instance; otherwise, <see langword="false"/>.</returns>
    public bool Equals(Point value)
        => X == value.X && Y == value.Y;

    /// <summary>
    /// Returns a value that indicates whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="value">The object to compare to this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is a <see cref="Point"/> that has the same <see cref="X"/> and <see cref="Y"/> as this instance; otherwise, <see langword="false"/>.</returns>
    public override bool Equals(object? value)
        => value is Point point && Equals(point);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    /// <summary>
    /// Returns a value indicating wether this instance is equal to a specified <see cref="Point"/>.
    /// </summary>
    /// <param name="left"><see cref="Point"/> to compare.</param>
    /// <param name="right"><see cref="Point"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> have the same <see cref="X"/> and <see cref="Y"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Point left, Point right)
        => Equals(left, right);

    /// <summary>
    /// Returns a value indicating wether this instance is not equal to a specified <see cref="Point"/>.
    /// </summary>
    /// <param name="left"><see cref="Point"/> to compare.</param>
    /// <param name="right"><see cref="Point"/> to compare.</param>
    /// <return><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> do not have the same <see cref="X"/> and <see cref="Y"/>; otherwise, <see langword="false"/>.</return>
    public static bool operator !=(Point left, Point right)
        => !Equals(left, right);
}

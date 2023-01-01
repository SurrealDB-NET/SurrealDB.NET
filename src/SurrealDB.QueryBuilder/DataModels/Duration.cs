using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SurrealDB.QueryBuilder.DataModels;

/// <summary>
/// Represents a duration of time with year to nanosecond precision. It is equivalent to SurrealDB's Duration data type.
/// </summary>
public readonly struct Duration : IComparable, IComparable<Duration>, IEquatable<Duration>, IParsable<Duration>, ISpanParsable<Duration>
{
    /// <summary>
    /// Gets the years component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The years component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Years { get; }

    /// <summary>
    /// Gets the weeks component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The weeks component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Weeks { get; }

    /// <summary>
    /// Gets the days component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The days component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Days { get; }

    /// <summary>
    /// Gets the hours component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The hours component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Hours { get; }

    /// <summary>
    /// Gets the minutes component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The minutes component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Minutes { get; }

    /// <summary>
    /// Gets the seconds component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The seconds component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Seconds { get; }

    /// <summary>
    /// Gets the nanoseconds component of this <see cref="Duration"/> structure.
    /// </summary>
    /// <returns>The nanoseconds component of this <see cref="Duration"/> structure.</returns>
    public readonly ulong Nanoseconds { get; }

    /// <summary>
    /// The largest unit of time in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly TimeUnit _largestUnit;

    /// <summary>
    /// The total number of seconds in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly UInt128 _totalSeconds => Years * 31536000 + Weeks * 604800 + Days * 86400 + Hours * 3600 + Minutes * 60 + Seconds;

    /// <summary>
    /// The total number of minutes in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly UInt128 _totalMinutes => Years * 525600 + Weeks * 10080 + Days * 1440 + Hours * 60 + Minutes;

    /// <summary>
    /// The total number of hours in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly UInt128 _totalHours => Years * 8760 + Weeks * 168 + Days * 24 + Hours;

    /// <summary>
    /// The total number of days in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly UInt128 _totalDays => Years * 365 + Weeks * 7 + Days;

    /// <summary>
    /// The total number of weeks in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly UInt128 _totalWeeks => Years * 52 + Weeks;

    /// <summary>
    /// The total number of years in this <see cref="Duration"/> structure. Utilized in division between <see cref="Duration"/> structures.
    /// </summary>
    private readonly decimal _totalYears;

    /// <summary>
    /// Initializes a new structure of the <see cref="Duration"/> structure with the specified components.
    /// </summary>
    /// <param name="years">Number of years.</param>
    /// <param name="weeks">Number of weeks.</param>
    /// <param name="days">Number of days.</param>
    /// <param name="hours">Number of hours.</param>
    /// <param name="minutes">Number of minutes.</param>
    /// <param name="seconds">Number of seconds.</param>
    /// <param name="milliseconds">Number of milliseconds.</param>
    /// <param name="microseconds">Number of microseconds.</param>
    /// <param name="nanoseconds">Number of nanoseconds.</param>
    /// <exception cref="OverflowException">The resulting <see cref="Duration"/> structure is too large.</exception>
    public Duration(
        ulong years = 0UL,
        ulong weeks = 0UL,
        ulong days = 0UL,
        ulong hours = 0UL,
        ulong minutes = 0UL,
        ulong seconds = 0UL,
        ulong milliseconds = 0UL,
        ulong microseconds = 0UL,
        ulong nanoseconds = 0UL)
    {
        nanoseconds += microseconds * 1000;
        nanoseconds += milliseconds * 1000000;
        seconds += nanoseconds / 1000000000;
        nanoseconds %= 1000000000;
        minutes += seconds / 60;
        seconds %= 60;
        hours += minutes / 60;
        minutes %= 60;
        days += hours / 24;
        hours %= 24;
        weeks += days / 7;
        days %= 7;
        _totalYears = years + weeks / (365M / 7M);
        years += weeks / 52;
        weeks %= 52;

        Years = years;
        Weeks = weeks;
        Days = days;
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Nanoseconds = nanoseconds;

        if (Years > 0)
            _largestUnit = TimeUnit.Years;
        else if (Weeks > 0)
            _largestUnit = TimeUnit.Weeks;
        else if (Days > 0)
            _largestUnit = TimeUnit.Days;
        else if (Hours > 0)
            _largestUnit = TimeUnit.Hours;
        else if (Minutes > 0)
            _largestUnit = TimeUnit.Minutes;
        else if (Seconds > 0)
            _largestUnit = TimeUnit.Seconds;
        else
            _largestUnit = TimeUnit.Nanoseconds;
    }

    /// <summary>
    /// Implicitly converts a formatted <see cref="string"/> to a <see cref="Duration"/> structure.
    /// </summary>
    /// <param name="duration">The formatted <see cref="string"/> to convert.</param>
    /// <exception cref="FormatException">The <paramref name="duration"/> parameter is not in a recognized format.</exception>
    public static implicit operator Duration(string duration)
    {
        ulong years = 0, weeks = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0, microseconds = 0, nanoseconds = 0;

        HashSet<string> units = new() { "y", "w", "d", "h", "m", "s", "ms", "µs", "ns" };

        for (int i = 0; i < duration.Length; i++)
        {
            string value = "", unit = "";

            while (i < duration.Length && char.IsDigit(duration[i]))
                value += duration[i++];

            while (i < duration.Length && !char.IsDigit(duration[i]))
                unit += duration[i++];
            --i;

            if (value != "" && units.Contains(unit))
            {
                switch (unit)
                {
                    case "y":
                        years += ulong.Parse(value);
                        break;
                    case "w":
                        weeks += ulong.Parse(value);
                        break;
                    case "d":
                        days += ulong.Parse(value);
                        break;
                    case "h":
                        hours += ulong.Parse(value);
                        break;
                    case "m":
                        minutes += ulong.Parse(value);
                        break;
                    case "s":
                        seconds += ulong.Parse(value);
                        break;
                    case "ms":
                        milliseconds += ulong.Parse(value);
                        break;
                    case "µs":
                        microseconds += ulong.Parse(value);
                        break;
                    case "ns":
                        nanoseconds += ulong.Parse(value);
                        break;
                }
            }
            else
                throw new FormatException("Invalid duration format.");
        }

        return new Duration(years, weeks, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds);
    }

    /// <summary>
    /// Converts the <see cref="string"/> representation of a duration to its <see cref="Duration"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="string"/> containing a <see cref="Duration"/> to convert.</param>
    /// <returns>A <see cref="Duration"/> equivalent to the duration contained in <paramref name="s"/>.</returns>
    /// <exception cref="FormatException">The <paramref name="s"/> parameter is not in a recognized format.</exception>
    public static Duration Parse(string s, IFormatProvider? provider = null)
        => s;

    /// <summary>
    /// Converts the span of representation of a duration to its <see cref="Duration"/> equivalent.
    /// </summary>
    /// <param name="s">A span containing a <see cref="Duration"/> to convert.</param>
    /// <returns>A <see cref="Duration"/> equivalent to the duration contained in <paramref name="s"/>.</returns>
    /// <exception cref="FormatException">The <paramref name="s"/> parameter is not in a recognized format.</exception>
    public static Duration Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null)
        => s.ToString();

    /// <summary>
    /// Converts the <see cref="string"/> representation of a duration to its <see cref="Duration"/> equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="string"/> containing a <see cref="Duration"/> to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="Duration"/> value equivalent to the duration contained in <paramref name="s"/>, if the conversion succeeded, or an empty <see cref="Duration"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not of the correct format. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Duration result)
    {
        if (s is null)
        {
            result = default;
            return false;
        }

        try
        {
            result = Parse(s);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Converts the <see cref="string"/> representation of a duration to its <see cref="Duration"/> equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A span containing a <see cref="Duration"/> to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="Duration"/> value equivalent to the duration contained in <paramref name="s"/>, if the conversion succeeded, or an empty <see cref="Duration"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or <see cref="string.Empty"/>, is not of the correct format. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Duration result)
        => TryParse(s.ToString(), null, out result);

    /// <summary>
    /// Compares this instance to a specified <see cref="Duration"/> and returns an integer that indicates whether the value of this instance is shorter than, equal to, or longer than the value of the specified <see cref="Duration"/>.
    /// </summary>
    /// <param name="value">A <see cref="Duration"/> to compare.</param>
    /// do new lines to explain the return value
    /// <returns>
    /// Value - Description <para/>
    /// -1 - This instance is shorter than <paramref name="value"/>. <para/>
    /// 0 - This instance is equal to <paramref name="value"/>. <para/>
    /// 1 - This instance is longer than <paramref name="value"/>. <para/>
    /// </returns>
    public int CompareTo(Duration value)
    {
        if (this > value)
            return 1;
        else if (this < value)
            return -1;
        else
            return 0;
    }

    /// <summary>
    /// Compares this instance to a specified object and returns an indication of their relative values.
    /// </summary>
    /// <param name="value">An object to compare, or <see langword="null"/>.</param>
    /// <returns>
    /// Value - Description <para/>
    /// -1 - This instance is shorter than <paramref name="value"/>. <para/>
    /// 0 - This instance is equal to <paramref name="value"/>. <para/>
    /// 1 - This instance is longer than, or, <paramref name="value"/> is <see langword="null"/>. <para/>
    /// </returns>
    /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="Duration"/>.</exception>
    public int CompareTo(object? value)
    {
        if (value is null)
            return 1;

        if (value is Duration duration)
            return CompareTo(duration);
        else
            throw new ArgumentException($"{nameof(value)} must be of type {nameof(Duration)} to be compared.");
    }

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified <see cref="Duration"/>.
    /// </summary>
    /// <param name="value">A <see cref="Duration"/> to compare to this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> has the same total time as this instance; otherwise, <see langword="false"/>.</returns>
    public bool Equals(Duration value)
        => Years == value.Years
        && Weeks == value.Weeks
        && Days == value.Days
        && Hours == value.Hours
        && Minutes == value.Minutes
        && Seconds == value.Seconds
        && Nanoseconds == value.Nanoseconds;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="value">An object to compare to this instance.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> is <see cref="Duration"/> that has the same total time as this instance; otherwise, <see langword="false"/>.</returns>
    public override bool Equals([NotNullWhen(true)] object? value)
        => value is Duration duration
        && Equals(duration);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
        => HashCode.Combine(Years, Weeks, Days, Hours, Minutes, Seconds, Nanoseconds);

    /// <summary>
    /// Returns a <see cref="string"/> that represents the current <see cref="Duration"/>.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents the current <see cref="Duration"/>.</returns>
    public override string ToString()
    {
        var duration = new StringBuilder();

        if (Years > 0)
            duration.Append($"{Years}y");
        if (Weeks > 0)
            duration.Append($"{Weeks}w");
        if (Days > 0)
            duration.Append($"{Days}d");
        if (Hours > 0)
            duration.Append($"{Hours}h");
        if (Minutes > 0)
            duration.Append($"{Minutes}m");
        if (Seconds > 0)
            duration.Append($"{Seconds}s");
        if (Nanoseconds > 0)
            duration.Append($"{Nanoseconds}ns");

        return duration.ToString();
    }

    /// <summary>
    /// Adds two specified <see cref="Duration"/> instances.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to add.</param>
    /// <param name="d2">The second <see cref="Duration"/> to add.</param>
    /// <returns>A <see cref="Duration"/> whose value is the sum of the values of <paramref name="d1"/> and <paramref name="d2"/>.</returns>
    /// <exception cref="OverflowException">The resulting <see cref="Duration"/> is too large.</exception>
    public static Duration operator +(Duration d1, Duration d2)
        => new Duration(
            d1.Years + d2.Years,
            d1.Weeks + d2.Weeks,
            d1.Days + d2.Days,
            d1.Hours + d2.Hours,
            d1.Minutes + d2.Minutes,
            d1.Seconds + d2.Seconds,
            d1.Nanoseconds + d2.Nanoseconds);

    /// <summary>
    /// Subtracts two specified <see cref="Duration"/> instances.
    /// </summary>
    /// <param name="d1">The <see cref="Duration"/> to subtract from.</param>
    /// <param name="d2">The <see cref="Duration"/> to subtract by.</param>
    /// <returns>A <see cref="Duration"/> whose value is the result of the value of <paramref name="d1"/> minus the value of <paramref name="d2"/>.</returns>
    /// <exception cref="ArithmeticException">The second <see cref="Duration"/> is longer than the first, <see cref="Duration"/> cannot be negative.</exception>
    public static Duration operator -(Duration d1, Duration d2)
    {
        if (d2 > d1)
            throw new ArithmeticException($"{nameof(d2)} cannot be longer than {nameof(d1)}, {nameof(Duration)} cannot be negative");

        return new Duration(
            d1.Years - d2.Years,
            d1.Weeks - d2.Weeks,
            d1.Days - d2.Days,
            d1.Hours - d2.Hours,
            d1.Minutes - d2.Minutes,
            d1.Seconds - d2.Seconds,
            d1.Nanoseconds - d2.Nanoseconds);
    }

    /// <summary>
    /// Multiplies two specified <see cref="Duration"/> instances by multiplying their total seconds.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to multiply.</param>
    /// <param name="d2">The second <see cref="Duration"/> to multiply.</param>
    /// <returns>The total seconds of <paramref name="d1"/> multiplied by the total seconds of <paramref name="d2"/>.</returns>
    public static UInt128 operator *(Duration d1, Duration d2)
        => d1._totalSeconds * d2._totalSeconds;

    /// <summary>
    /// Divides two specified <see cref="Duration"/> instances in terms of their least common unit. The smallest common unit in this context is <see cref="Duration.Seconds"/>
    /// to comply with SurrealDB's implmentation. Therefore, if either <paramref name="d1"/> and <paramref name="d2"/> is shorter than <see cref="Duration.Seconds"/>,
    /// they are treated as 0s.
    /// </summary>
    /// <param name="d1">The <see cref="Duration"/> to divide from.</param>
    /// <param name="d2">The <see cref="Duration"/> to divide by.</param>
    /// <returns>
    /// If the largest unit of <paramref name="d2"/> is nanoseconds, <see langword="null"/> is returned to avoid division by zero. If the largest unit of
    /// <paramref name="d1"/> is nanoseconds, "0" is returned, otherwise the result of the division is returned as a division of their least common unit as a <see cref="string"/>.
    /// </returns>
    public static string? operator /(Duration d1, Duration d2)
    {
        if (d2._largestUnit == TimeUnit.Nanoseconds)
            return null;
        if (d1._largestUnit == TimeUnit.Nanoseconds)
            return "0";

        var commonUnit = d1._largestUnit < d2._largestUnit ? d1._largestUnit : d2._largestUnit;

        return commonUnit switch
        {
            TimeUnit.Seconds => ((decimal)d1._totalSeconds / (decimal)d2._totalSeconds).ToString(),
            TimeUnit.Minutes => ((decimal)d1._totalMinutes / (decimal)d2._totalMinutes).ToString(),
            TimeUnit.Hours => ((decimal)d1._totalHours / (decimal)d2._totalHours).ToString(),
            TimeUnit.Days => ((decimal)d1._totalDays / (decimal)d2._totalDays).ToString(),
            TimeUnit.Weeks => ((decimal)d1._totalWeeks / (decimal)d2._totalWeeks).ToString(),
            TimeUnit.Years => (d1._totalYears / d2._totalYears).ToString(),
            _ => null
        };
    }

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">A <see cref="Duration"/> to compare.</param>
    /// <param name="d2">A <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> has the same total time as this instance; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Duration d1, Duration d2)
        => Equals(d1, d2);

    /// <summary>
    /// Returns a value indicating whether this instance is not equal to a specified <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">A <see cref="Duration"/> to compare.</param>
    /// <param name="d2">A <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="value"/> does not have the same total time as this instance; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(Duration d1, Duration d2)
        => !Equals(d1, d2);

    /// <summary>
    /// Returns a value indicating whether this instance is less than a specified <see cref="Duration"/>. The comparison is done by comparing the total time of each 
    /// <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to compare.</param>
    /// <param name="d2">The second <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="d1"/> is shorter than <paramref name="d2"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator <(Duration d1, Duration d2)
        => d1.Years < d2.Years
        || d1.Weeks < d2.Weeks
        || d1.Days < d2.Days
        || d1.Hours < d2.Hours
        || d1.Minutes < d2.Minutes
        || d1.Seconds < d2.Seconds
        || d1.Nanoseconds < d2.Nanoseconds;

    /// <summary>
    /// Returns a value indicating whether this instance is greater than a specified <see cref="Duration"/>. The comparison is done by comparing the total time of each
    /// <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to compare.</param>
    /// <param name="d2">The second <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="d1"/> is longer than <paramref name="d2"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator >(Duration d1, Duration d2)
        => d1.Years > d2.Years
        || d1.Weeks > d2.Weeks
        || d1.Days > d2.Days
        || d1.Hours > d2.Hours
        || d1.Minutes > d2.Minutes
        || d1.Seconds > d2.Seconds
        || d1.Nanoseconds > d2.Nanoseconds;

    /// <summary>
    /// Returns a value indicating whether this instance is less than or equal to a specified <see cref="Duration"/>. The comparison is done by comparing the total time of each
    /// <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to compare.</param>
    /// <param name="d2">The second <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="d1"/> is shorter than or equal to <paramref name="d2"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator <=(Duration d1, Duration d2)
        => d1.Years <= d2.Years
        || d1.Weeks <= d2.Weeks
        || d1.Days <= d2.Days
        || d1.Hours <= d2.Hours
        || d1.Minutes <= d2.Minutes
        || d1.Seconds <= d2.Seconds
        || d1.Nanoseconds <= d2.Nanoseconds;

    /// <summary>
    /// Returns a value indicating whether this instance is greater than or equal to a specified <see cref="Duration"/>. The comparison is done by comparing the total time of each
    /// <see cref="Duration"/>.
    /// </summary>
    /// <param name="d1">The first <see cref="Duration"/> to compare.</param>
    /// <param name="d2">The second <see cref="Duration"/> to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="d1"/> is longer than or equal to <paramref name="d2"/>; otherwise, <see langword="false"/>.</returns>
    public static bool operator >=(Duration d1, Duration d2)
        => d1.Years >= d2.Years
        || d1.Weeks >= d2.Weeks
        || d1.Days >= d2.Days
        || d1.Hours >= d2.Hours
        || d1.Minutes >= d2.Minutes
        || d1.Seconds >= d2.Seconds
        || d1.Nanoseconds >= d2.Nanoseconds;

    /// <summary>
    /// Adds a <see cref="Duration"/> to a <see cref="DateTime"/> and returns the <see cref="DateTime"/> instance with the total time of the <see cref="Duration"/> added to it.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> to add the <see cref="Duration"/> to.</param>
    /// <param name="duration">The <see cref="Duration"/> to add to the <see cref="DateTime"/>.</param>
    /// <returns><paramref name="dateTime"/> with the total time of <paramref name="duration"/> added to it.</returns>
    public static DateTime operator +(DateTime dateTime, Duration duration)
        => dateTime
            .AddYears((int)duration.Years)
            .AddDays((int)duration.Weeks * 7 + (int)duration.Days)
            .AddHours((int)duration.Hours)
            .AddMinutes((int)duration.Minutes)
            .AddSeconds((int)duration.Seconds)
            .AddTicks((long)duration.Nanoseconds / 100);

    /// <summary>
    /// Adds a <see cref="Duration"/> to a <see cref="DateTimeOffset"/> and returns the <see cref="DateTimeOffset"/> instance with the total time of the <see cref="Duration"/>
    /// added to it.
    /// </summary>
    /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> to add the <see cref="Duration"/> to.</param>
    /// <param name="duration">The <see cref="Duration"/> to add to the <see cref="DateTimeOffset"/>.</param>
    /// <returns><paramref name="dateTimeOffset"/> with the total time of <paramref name="duration"/> added to it.</returns>
    public static DateTimeOffset operator +(DateTimeOffset dateTimeOffset, Duration duration)
        => dateTimeOffset
            .AddYears((int)duration.Years)
            .AddDays((int)duration.Weeks * 7 + (int)duration.Days)
            .AddHours((int)duration.Hours)
            .AddMinutes((int)duration.Minutes)
            .AddSeconds((int)duration.Seconds)
            .AddTicks((long)duration.Nanoseconds / 100);

    /// <summary>
    /// Subtracts a <see cref="Duration"/> from a <see cref="DateTime"/> and returns the <see cref="DateTime"/> instance with the total time of the <see cref="Duration"/> subtracted
    /// from it.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> to subtract the <see cref="Duration"/> from.</param>
    /// <param name="duration">The <see cref="Duration"/> to subtract from the <see cref="DateTime"/>.</param>
    /// <returns><paramref name="dateTime"/> with the total time of <paramref name="duration"/> subtracted from it.</returns>
    public static DateTime operator -(DateTime dateTime, Duration duration)
        => dateTime
            .AddYears(-(int)duration.Years)
            .AddDays(-(int)duration.Weeks * 7 - (int)duration.Days)
            .AddHours(-(int)duration.Hours)
            .AddMinutes(-(int)duration.Minutes)
            .AddSeconds(-(int)duration.Seconds)
            .AddTicks(-(long)duration.Nanoseconds / 100);

    /// <summary>
    /// Subtracts a <see cref="Duration"/> from a <see cref="DateTimeOffset"/> and returns the <see cref="DateTimeOffset"/> instance with the total time of the <see cref="Duration"/>
    /// subtracted from it.
    /// </summary>
    /// <param name="dateTimeOffset">The <see cref="DateTimeOffset"/> to subtract the <see cref="Duration"/> from.</param>
    /// <param name="duration">The <see cref="Duration"/> to subtract from the <see cref="DateTimeOffset"/>.</param>
    /// <returns><paramref name="dateTimeOffset"/> with the total time of <paramref name="duration"/> subtracted from it.</returns>
    public static DateTimeOffset operator -(DateTimeOffset dateTimeOffset, Duration duration)
        => dateTimeOffset
            .AddYears(-(int)duration.Years)
            .AddDays(-(int)duration.Weeks * 7 - (int)duration.Days)
            .AddHours(-(int)duration.Hours)
            .AddMinutes(-(int)duration.Minutes)
            .AddSeconds(-(int)duration.Seconds)
            .AddTicks(-(long)duration.Nanoseconds / 100);

    /// <summary>
    /// Used to determine the largest unit that this <see cref="Duration"/> instance 
    /// has.
    /// </summary>
    internal enum TimeUnit
    {
        Nanoseconds,
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks,
        Years
    }
}
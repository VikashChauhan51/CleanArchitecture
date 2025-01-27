namespace CleanArchitecture.Domain.Abstractions.Providers;

public interface ITimeProvider
{
    /// <summary>
    /// Gets a <see cref="DateTimeOffset"/> value whose date and time are set to the current
    /// Coordinated Universal Time (UTC) date and time and whose offset is Zero,
    /// all according to this <see cref="TimeProvider"/>'s notion of time.
    /// </summary>
    DateTimeOffset GetUtcNow();

    /// <summary>
    /// Gets a <see cref="DateTimeOffset"/> value that is set to the current date and time according to this <see cref="TimeProvider"/>'s
    /// notion of time based on <see cref="GetUtcNow"/>, with the offset set to the <see cref="LocalTimeZone"/>'s offset from Coordinated Universal Time (UTC).
    /// </summary>
    DateTimeOffset GetLocalNow();

    /// <summary>
    /// Gets a <see cref="TimeZoneInfo"/> object that represents the local time zone according to this <see cref="TimeProvider"/>'s notion of time.
    /// </summary>
    TimeZoneInfo LocalTimeZone { get; }

    /// <summary>
    /// Gets the frequency of <see cref="GetTimestamp"/> of high-frequency value per second.
    /// </summary>
    long TimestampFrequency { get; }

    /// <summary>
    /// Gets the current high-frequency value designed to measure small time intervals with high accuracy in the timer mechanism.
    /// </summary>
    /// <returns>A long integer representing the high-frequency counter value of the underlying timer mechanism. </returns>
    long GetTimestamp();

    /// <summary>
    /// Gets the elapsed time between two timestamps retrieved using <see cref="GetTimestamp"/>.
    /// </summary>
    /// <param name="startingTimestamp">The timestamp marking the beginning of the time period.</param>
    /// <param name="endingTimestamp">The timestamp marking the end of the time period.</param>
    /// <returns>A <see cref="TimeSpan"/> for the elapsed time between the starting and ending timestamps.</returns>
    TimeSpan GetElapsedTime(long startingTimestamp, long endingTimestamp);

    /// <summary>
    /// Gets the elapsed time since the <paramref name="startingTimestamp"/> value retrieved using <see cref="GetTimestamp"/>.
    /// </summary>
    /// <param name="startingTimestamp">The timestamp marking the beginning of the time period.</param>
    /// <returns>A <see cref="TimeSpan"/> for the elapsed time between the starting timestamp and the time of this call.</returns>
    TimeSpan GetElapsedTime(long startingTimestamp);

    /// <summary>
    /// Creates a new <see cref="ITimer"/> instance, using <see cref="TimeSpan"/> values to measure time intervals.
    /// </summary>
    /// <param name="callback">A delegate representing a method to be executed when the timer fires.</param>
    /// <param name="state">An object to be passed to the <paramref name="callback"/>. This may be null.</param>
    /// <param name="dueTime">The amount of time to delay before <paramref name="callback"/> is invoked.</param>
    /// <param name="period">The time interval between invocations of <paramref name="callback"/>.</param>
    /// <returns>The newly created <see cref="ITimer"/> instance.</returns>
    ITimer CreateTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period);
}

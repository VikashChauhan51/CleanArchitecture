using CleanArchitecture.Abstractions.Providers;

namespace CleanArchitecture.Infrastructure.Providers;

/// <summary>
/// Provides the current date and time using the system clock.
/// </summary>
public sealed class DateTimeProvider : TimeProvider, ITimeProvider
{
    // Inherits all functionality from TimeProvider and ITimeProvider.
}

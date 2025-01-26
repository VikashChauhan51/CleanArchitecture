using CleanArchitecture.SharedKernel.Providers;

namespace CleanArchitecture.Infrastructure.Providers;
public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}

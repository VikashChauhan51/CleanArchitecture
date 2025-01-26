namespace CleanArchitecture.Domain.Abstractions.Providers;
public interface IDateTimeProvider
{
    public DateTimeOffset UtcNow { get; }
}


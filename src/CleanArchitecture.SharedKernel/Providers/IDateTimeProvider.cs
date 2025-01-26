namespace CleanArchitecture.SharedKernel.Providers;
public interface IDateTimeProvider
{
    public DateTimeOffset UtcNow { get; }
}

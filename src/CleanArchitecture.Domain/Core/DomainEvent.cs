namespace CleanArchitecture.Domain.Core;
public abstract record class DomainEvent : IDomainEvent
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
}

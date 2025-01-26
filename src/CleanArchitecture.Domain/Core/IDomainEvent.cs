
namespace CleanArchitecture.Domain.Core;
public interface IDomainEvent
{
    string Id { get; }
    DateTimeOffset OccurredOn { get; }
}

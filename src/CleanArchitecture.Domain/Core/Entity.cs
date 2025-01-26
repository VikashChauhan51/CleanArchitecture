
namespace CleanArchitecture.Domain.Core;
public abstract class Entity<T> : IEntity<T> where T : notnull
{
    public T Id { get; set; } = default!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

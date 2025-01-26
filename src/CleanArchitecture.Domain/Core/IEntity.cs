namespace CleanArchitecture.Domain.Core;

public interface IEntity<T> : IEntity where T : notnull
{
    public T Id { get; set; }
}

public interface IEntity
{
    public DateTimeOffset CreatedAt { get; set; }
}

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories;
public interface IWriteRepositoryAsync<in T, in TKey> where T : IEntity where TKey : notnull
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}

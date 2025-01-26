using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories;
public interface IWriteRepository<in T, in TKey> where T : IEntity where TKey : notnull
{
    void Add(T entity);
    void Update(T entity);
    void Delete(TKey id);
}

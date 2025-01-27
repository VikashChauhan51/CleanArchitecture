using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories.Core;
public interface IWriteRepository<in T, in TKey> where T : IEntity where TKey : notnull
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(TKey id);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
}

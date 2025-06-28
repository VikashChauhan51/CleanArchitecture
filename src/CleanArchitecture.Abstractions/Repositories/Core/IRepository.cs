using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Abstractions.Repositories.Core;
public interface IRepositoryAsync<T, TKey> : IReadRepository<T, TKey>, IWriteRepositoryAsync<T, TKey> where T : IEntity where TKey : notnull
{

}

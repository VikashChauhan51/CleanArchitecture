using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories;
public interface IRepositoryAsync<T, TKey> : IReadRepositoryAsync<T, TKey>, IWriteRepositoryAsync<T, TKey> where T : IEntity where TKey : notnull
{

}

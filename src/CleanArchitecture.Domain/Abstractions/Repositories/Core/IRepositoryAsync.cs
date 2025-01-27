using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories.Core;
public interface IRepositoryAsync<T, TKey> : IReadRepositoryAsync<T, TKey>, IWriteRepositoryAsync<T, TKey> where T : IEntity where TKey : notnull
{

}

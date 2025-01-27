using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Abstractions.Repositories.Core;
public interface IRepository<T, TKey> : IReadRepository<T, TKey>, IWriteRepository<T, TKey> where T : IEntity where TKey : notnull
{

}

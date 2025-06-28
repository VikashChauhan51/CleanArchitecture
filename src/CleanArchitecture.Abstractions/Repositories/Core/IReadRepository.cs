using CleanArchitecture.Domain.Core;
using System.Linq.Expressions;

namespace CleanArchitecture.Abstractions.Repositories.Core;
public interface IReadRepository<T, in TKey> where T : IEntity where TKey : notnull
{
    Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<PaginatedResult<T>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}

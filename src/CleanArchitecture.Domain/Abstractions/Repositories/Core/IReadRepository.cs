using CleanArchitecture.Domain.Core;
using System.Linq.Expressions;


namespace CleanArchitecture.Domain.Abstractions.Repositories.Core;
public interface IReadRepository<T, in TKey> where T : IEntity where TKey : notnull
{
    T? GetById(TKey id);
    IQueryable<T> GetQueryable();
    IEnumerable<T> GetAll();
    PaginatedResult<T> GetPagedList(int pageSize, int pageNumber);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}


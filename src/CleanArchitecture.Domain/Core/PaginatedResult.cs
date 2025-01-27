namespace CleanArchitecture.Domain.Core;
public sealed record class PaginatedResult<TEntity>
(
    long Count,
    long PageNumber,
    long PageSize,
    long PageCount,
    long TotalItemCount,
    bool HasPreviousPage,
    bool HasNextPage,
    bool IsFirstPage,
    bool IsLastPage,
    IEnumerable<TEntity> Entities
) where TEntity : IEntity;

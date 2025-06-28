// <copyright file="IReadRepository.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;
using System.Linq.Expressions;

namespace CleanArchitecture.Abstractions.Repositories.Core;

/// <summary>
/// Defines asynchronous read operations for a repository.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public interface IReadRepository<T, in TKey>
    where T : IEntity
    where TKey : notnull
{
    /// <summary>
    /// Gets an entity by its key asynchronously.
    /// </summary>
    /// <param name="id">The key of the entity.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all entities asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A collection of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a paginated list of entities asynchronously.
    /// </summary>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A paginated result of entities.</returns>
    Task<PaginatedResult<T>> GetPagedListAsync(int pageSize, int pageNumber, CancellationToken cancellationToken);

    /// <summary>
    /// Finds entities matching the specified predicate asynchronously.
    /// </summary>
    /// <param name="predicate">The filter expression.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A collection of matching entities.</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
}

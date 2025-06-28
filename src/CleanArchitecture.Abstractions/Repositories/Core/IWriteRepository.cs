// <copyright file="IWriteRepository.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Abstractions.Repositories.Core;

/// <summary>
/// Defines asynchronous write operations for a repository.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public interface IWriteRepositoryAsync<in T, in TKey>
    where T : IEntity
    where TKey : notnull
{
    /// <summary>
    /// Adds an entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Adds a range of entities asynchronously.
    /// </summary>
    /// <param name="entities">The entities to add.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes an entity by its key asynchronously.
    /// </summary>
    /// <param name="id">The key of the entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes an entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}

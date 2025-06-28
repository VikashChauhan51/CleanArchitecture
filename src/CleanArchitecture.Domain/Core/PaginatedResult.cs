// <copyright file="PaginatedResult.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

/// <summary>
/// Represents a paginated result set for a collection of entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entities in the result set.</typeparam>
/// <param name="Count">The number of items in the current page.</param>
/// <param name="PageNumber">The current page number.</param>
/// <param name="PageSize">The size of each page.</param>
/// <param name="PageCount">The total number of pages.</param>
/// <param name="TotalItemCount">The total number of items across all pages.</param>
/// <param name="HasPreviousPage">Indicates if there is a previous page.</param>
/// <param name="HasNextPage">Indicates if there is a next page.</param>
/// <param name="IsFirstPage">Indicates if this is the first page.</param>
/// <param name="IsLastPage">Indicates if this is the last page.</param>
/// <param name="Entities">The collection of entities in the current page.</param>
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
    IEnumerable<TEntity> Entities)
    where TEntity : IEntity;

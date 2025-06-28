// <copyright file="IRepository.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Abstractions.Repositories.Core;

/// <summary>
/// Defines a generic asynchronous repository interface for read and write operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public interface IRepositoryAsync<T, TKey> : IReadRepository<T, TKey>, IWriteRepositoryAsync<T, TKey>
    where T : IEntity
    where TKey : notnull
{
}

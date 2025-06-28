// <copyright file="Entity.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

/// <summary>
/// Represents the base class for all entities with a strongly-typed identifier.
/// </summary>
/// <typeparam name="T">
/// The type of the entity identifier.
/// </typeparam>
public abstract class Entity<T> : IEntity<T>
    where T : notnull
{
    /// <inheritdoc/>
    public T Id { get; set; } = default!;

    /// <inheritdoc/>
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}

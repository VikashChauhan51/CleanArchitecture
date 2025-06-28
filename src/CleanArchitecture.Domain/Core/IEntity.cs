// <copyright file="IEntity.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

/// <summary>
/// Represents a generic entity with an identifier.
/// </summary>
/// <typeparam name="T">The type of the entity's identifier.</typeparam>
public interface IEntity<T> : IEntity
    where T : notnull
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    T Id { get; set; }
}

/// <summary>
/// Represents a base entity with creation timestamp.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the creation timestamp of the entity.
    /// </summary>
    DateTimeOffset CreatedAt { get; set; }
}

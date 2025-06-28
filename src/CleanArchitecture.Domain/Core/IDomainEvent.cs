// <copyright file="IDomainEvent.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

/// <summary>
/// Represents a domain event in the system.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the unique identifier for the domain event.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the timestamp when the event occurred.
    /// </summary>
    DateTimeOffset OccurredOn { get; }
}

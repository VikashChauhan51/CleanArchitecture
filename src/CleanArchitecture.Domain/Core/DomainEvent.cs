// <copyright file="DomainEvent.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

public abstract record class DomainEvent : IDomainEvent
{
    /// <inheritdoc/>
    public string Id { get; } = Guid.NewGuid().ToString();

    /// <inheritdoc/>
    public DateTimeOffset OccurredOn { get; } = DateTimeOffset.UtcNow;
}

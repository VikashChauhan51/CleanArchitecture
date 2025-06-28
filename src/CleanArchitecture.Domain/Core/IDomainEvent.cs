// <copyright file="IDomainEvent.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

public interface IDomainEvent
{
    string Id { get; }

    DateTimeOffset OccurredOn { get; }
}

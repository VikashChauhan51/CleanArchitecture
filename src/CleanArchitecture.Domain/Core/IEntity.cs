// <copyright file="IEntity.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Domain.Core;

public interface IEntity<T> : IEntity
    where T : notnull
{
    T Id { get; set; }
}

public interface IEntity
{
    DateTimeOffset CreatedAt { get; set; }
}

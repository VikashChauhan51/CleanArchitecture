// <copyright file="SignUpEvent.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Events;

/// <summary>
/// Represents a domain event that occurs when a user signs up.
/// </summary>
/// <param name="UserId">The unique identifier of the user who signed up.</param>
public sealed record class SignUpEvent(Guid UserId) : DomainEvent;

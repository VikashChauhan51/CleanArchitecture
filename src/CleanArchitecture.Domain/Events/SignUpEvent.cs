// <copyright file="SignUpEvent.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Events;

public sealed record class SignUpEvent(Guid UserId) : DomainEvent;

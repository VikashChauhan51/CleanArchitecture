// <copyright file="ProfileQuery.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using MediatorForge.Queries;

namespace CleanArchitecture.Application.UseCases.Profile;

public sealed record ProfileQuery(Guid UserId) : IQuery<Outcome<ProfileResponse>>;

// <copyright file="ProfileResponse.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Application.UseCases.Profile;

public sealed record ProfileResponse
(
    string FullName,
    string UserName);

// <copyright file="SignUpModel.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Abstractions.Models;

public sealed record SignUpModel
(
    string FullName,
    string UserName,
    string Password);

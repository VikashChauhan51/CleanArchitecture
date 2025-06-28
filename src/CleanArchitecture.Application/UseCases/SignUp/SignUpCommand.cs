// <copyright file="SignUpCommand.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using MediatorForge.Commands;

namespace CleanArchitecture.Application.UseCases.SignUp;

public sealed record SignUpCommand
(
    string FullName,
    string UserName,
    string Password) : ICommand<Outcome<string>>;

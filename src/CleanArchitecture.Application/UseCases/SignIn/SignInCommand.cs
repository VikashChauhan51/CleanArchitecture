// <copyright file="SignInCommand.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using MediatorForge.Commands;

namespace CleanArchitecture.Application.UseCases.SignIn;

public sealed record SignInCommand
(
    string UserName,
    string Password) : ICommand<Outcome<string>>;

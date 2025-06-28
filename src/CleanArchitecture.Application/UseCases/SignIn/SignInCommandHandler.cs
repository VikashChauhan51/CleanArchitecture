// <copyright file="SignInCommandHandler.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Abstractions.Managers;
using MediatorForge.Commands;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.SignIn;

internal sealed class SignInCommandHandler : ICommandHandler<SignInCommand, Outcome<string>>
{
    private readonly IUserManager userManager;
    private readonly ILogger<SignInCommandHandler> logger;

    public SignInCommandHandler(IUserManager userManager, ILogger<SignInCommandHandler> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
    }

    public async Task<Outcome<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        this.logger.LogInformation("SignInCommandHandler.Handle");
        return await this.userManager.SignInAsync(request.UserName, request.Password, cancellationToken).ConfigureAwait(false);
    }
}

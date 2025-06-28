// <copyright file="SignUpCommandHandler.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Abstractions.Managers;
using MediatorForge.Commands;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.SignUp;

internal sealed class SignUpCommandHandler : ICommandHandler<SignUpCommand, Outcome<string>>
{
    private readonly IUserManager userManager;
    private readonly ILogger<SignUpCommandHandler> logger;
    private readonly IPublisher publisher;

    public SignUpCommandHandler(IUserManager userManager, IPublisher publisher, ILogger<SignUpCommandHandler> logger)
    {
        this.logger = logger;
        this.userManager = userManager;
        this.publisher = publisher;
    }

    public async Task<Outcome<string>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.CreateVersion7();
        this.logger.LogInformation("SignUpCommandHandler.Handle");

        // return await _userManager.SignUpAsync(request.SignUpModel, cancellationToken);
        var signUpEvent = new SignUpEventNotification(new Domain.Events.SignUpEvent(userId));
        await this.publisher.Publish(signUpEvent, cancellationToken).ConfigureAwait(false);

        return Outcome<string>.Success(userId.ToString());
    }
}

// <copyright file="SignUpEventNotificationHandler.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using MediatorForge.Notifications;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.SignUp;

internal sealed class SignUpEventNotificationHandler : IEventNotificationHandler<SignUpEventNotification>
{
    private readonly ILogger<SignUpEventNotificationHandler> logger;

    public SignUpEventNotificationHandler(ILogger<SignUpEventNotificationHandler> logger)
    {
        this.logger = logger;
    }

    public Task Handle(SignUpEventNotification notification, CancellationToken cancellationToken)
    {
        this.logger.LogInformation($"SignUpEventNotificationHandler.Handle: {notification.Event.Id}");
        return Task.CompletedTask;
    }
}

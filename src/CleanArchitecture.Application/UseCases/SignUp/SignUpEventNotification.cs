// <copyright file="SignUpEventNotification.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Events;
using MediatorForge.Notifications;

namespace CleanArchitecture.Application.UseCases.SignUp;

public sealed class SignUpEventNotification : IEventNotification<SignUpEvent>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SignUpEventNotification"/> class.
    /// </summary>
    /// <param name="event"></param>
    public SignUpEventNotification(SignUpEvent @event)
    {
        this.Event = @event;
    }

    public SignUpEvent Event { get; }
}

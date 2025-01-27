﻿using CleanArchitecture.Domain.Events;
using MediatorForge.Notifications;


namespace CleanArchitecture.Application.UseCases.SignUp;
public class SignUpEventNotification : IEventNotification<SignUpEvent>
{
    public SignUpEventNotification(SignUpEvent @event)
    {
        Event = @event;
    }

    public SignUpEvent Event { get; }

}

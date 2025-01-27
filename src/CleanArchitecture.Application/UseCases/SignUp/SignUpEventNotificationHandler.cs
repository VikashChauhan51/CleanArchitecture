using MediatorForge.Notifications;


namespace CleanArchitecture.Application.UseCases.SignUp;
internal class SignUpEventNotificationHandler : IEventNotificationHandler<SignUpEventNotification>
{
    public Task Handle(IEventNotification<SignUpEventNotification> notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

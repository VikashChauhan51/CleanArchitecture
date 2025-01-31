using MediatorForge.Notifications;
using Microsoft.Extensions.Logging;


namespace CleanArchitecture.Application.UseCases.SignUp;
internal sealed class SignUpEventNotificationHandler : IEventNotificationHandler<SignUpEventNotification>
{
    private readonly ILogger<SignUpEventNotificationHandler> _logger;
    public SignUpEventNotificationHandler(ILogger<SignUpEventNotificationHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(SignUpEventNotification notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"SignUpEventNotificationHandler.Handle: {notification.Event.Id}");
        return Task.CompletedTask;
    }
}

using CleanArchitecture.Abstractions.Managers;
using MediatorForge.Commands;
using MediatR;
using Microsoft.Extensions.Logging;


namespace CleanArchitecture.Application.UseCases.SignUp;
internal sealed class SignUpCommandHandler : ICommandHandler<SignUpCommand, Outcome<string>>
{
    private readonly IUserManager _userManager;
    private readonly ILogger<SignUpCommandHandler> _logger;
    private IPublisher _publisher;
    public SignUpCommandHandler(IUserManager userManager, IPublisher publisher, ILogger<SignUpCommandHandler> logger)
    {
        _logger = logger;
        _userManager = userManager;
        _publisher = publisher;
    }
    public async Task<Outcome<string>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.CreateVersion7();
        _logger.LogInformation("SignUpCommandHandler.Handle");
        //return await _userManager.SignUpAsync(request.SignUpModel, cancellationToken);  
        var signUpEvent = new SignUpEventNotification(new Domain.Events.SignUpEvent(userId));
       await _publisher.Publish(signUpEvent, cancellationToken);

        return Outcome<string>.Success(userId.ToString());  

    }
}

using CleanArchitecture.Domain.Abstractions.Managers;
using MediatorForge.Commands;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.SignIn;
internal sealed class SignInCommandHandler : ICommandHandler<SignInCommand, Outcome<string>>
{
    private readonly IUserManager _userManager;
    private readonly ILogger<SignInCommandHandler> _logger;
    public SignInCommandHandler(IUserManager userManager, ILogger<SignInCommandHandler> logger)
    {
        _logger = logger;
        _userManager = userManager;
    }
    public async Task<Outcome<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SignInCommandHandler.Handle");
        return await _userManager.SignInAsync(request.UserName, request.Password, cancellationToken);

    }
}

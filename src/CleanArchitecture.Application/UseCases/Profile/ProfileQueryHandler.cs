using CleanArchitecture.Abstractions.Repositories;
using MediatorForge.Queries;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.Profile;
internal sealed class ProfileQueryHandler : IQueryHandler<ProfileQuery, Outcome<ProfileResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<ProfileQueryHandler> _logger;
    public ProfileQueryHandler
    (
        IUserRepository userRepository,
        ILogger<ProfileQueryHandler> logger
    )
    {
        _logger = logger;
        _userRepository = userRepository;
    }
    public async Task<Outcome<ProfileResponse>> Handle(ProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            _logger.LogInformation("ProfileQueryHandler.Handle: user not found with id: {UserId}", request.UserId);
            return Outcome<ProfileResponse>.NotFound(new OutcomeError("user not found"));
        }

        return Outcome<ProfileResponse>.Success(new ProfileResponse(user.FullName, user.UserName));
    }
}

using CleanArchitecture.Abstractions.Managers;
using CleanArchitecture.Abstractions.Models;
using CleanArchitecture.Abstractions.Providers;
using CleanArchitecture.Abstractions.Repositories;
using CleanArchitecture.Abstractions.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Logging;
using ResultifyCore;

namespace CleanArchitecture.Infrastructure.Managers;

/// <summary>
/// Provides user management operations such as sign-in and sign-up.
/// </summary>
public sealed class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<UserManager> _logger;
    public UserManager
    (
        IUserRepository userRepository,
        ITokenProvider tokenProvider,
        IPasswordHasher passwordHasher,
        ILogger<UserManager> logger
    )
    {
        _logger = logger;
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
        _passwordHasher = passwordHasher;

    }

    /// <inheritdoc />
    public async Task<Outcome<string>> SignInAsync(string userName, string password, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserNameAsync(userName, cancellationToken);
        if (user == null)
        {
            _logger.LogWarning("User not found");
            return Outcome<string>.NotFound(new OutcomeError("User not found"));
        }
        if (!_passwordHasher.VerifyHashedPassword(user.PasswordHash, password))
        {
            _logger.LogWarning("Invalid password");
            return Outcome<string>.NotFound(new OutcomeError("Invalid password"));
        }
        return Outcome<string>.Success(_tokenProvider.AccessToken(user));
    }

    /// <inheritdoc />
    public async Task<Outcome<User>> SignUpAsync(SignUpModel signUpModel, CancellationToken cancellationToken)
    {
        if (signUpModel is null)
        {
            return Outcome<User>.Validation(new OutcomeError("Invalid model"));
        }
        var user = await _userRepository.GetByUserNameAsync(signUpModel.UserName, cancellationToken);
        if (user != null)
        {
            _logger.LogWarning("User already exists");
            return Outcome<User>.Conflict(new OutcomeError("User already exists"));
        }

        user = new User
        {
            Id = Guid.CreateVersion7(),
            FullName = signUpModel.FullName,
            UserName = signUpModel.UserName,
            PasswordHash = _passwordHasher.HashPassword(signUpModel.Password),
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user, cancellationToken);
        return Outcome<User>.Success(user);
    }

}

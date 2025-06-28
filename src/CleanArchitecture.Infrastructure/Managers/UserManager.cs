// <copyright file="UserManager.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

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
    private readonly IUserRepository userRepository;
    private readonly ITokenProvider tokenProvider;
    private readonly IPasswordHasher passwordHasher;
    private readonly ILogger<UserManager> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserManager"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="tokenProvider"></param>
    /// <param name="passwordHasher"></param>
    /// <param name="logger"></param>
    public UserManager(
        IUserRepository userRepository,
        ITokenProvider tokenProvider,
        IPasswordHasher passwordHasher,
        ILogger<UserManager> logger)
    {
        this.logger = logger;
        this.userRepository = userRepository;
        this.tokenProvider = tokenProvider;
        this.passwordHasher = passwordHasher;
    }

    /// <inheritdoc />
    public async Task<Outcome<string>> SignInAsync(string userName, string password, CancellationToken cancellationToken)
    {
        var user = await this.userRepository.GetByUserNameAsync(userName, cancellationToken).ConfigureAwait(false);
        if (user == null)
        {
            this.logger.LogWarning("User not found");
            return Outcome<string>.NotFound(new OutcomeError("User not found"));
        }

        if (!this.passwordHasher.VerifyHashedPassword(user.PasswordHash, password))
        {
            this.logger.LogWarning("Invalid password");
            return Outcome<string>.NotFound(new OutcomeError("Invalid password"));
        }

        return Outcome<string>.Success(this.tokenProvider.AccessToken(user));
    }

    /// <inheritdoc />
    public async Task<Outcome<User>> SignUpAsync(SignUpModel signUpModel, CancellationToken cancellationToken)
    {
        if (signUpModel is null)
        {
            return Outcome<User>.Validation(new OutcomeError("Invalid model"));
        }

        var user = await this.userRepository.GetByUserNameAsync(signUpModel.UserName, cancellationToken).ConfigureAwait(false);
        if (user != null)
        {
            this.logger.LogWarning("User already exists");
            return Outcome<User>.Conflict(new OutcomeError("User already exists"));
        }

        user = new User
        {
            Id = Guid.CreateVersion7(),
            FullName = signUpModel.FullName,
            UserName = signUpModel.UserName,
            PasswordHash = this.passwordHasher.HashPassword(signUpModel.Password),
            CreatedAt = DateTime.UtcNow,
        };

        await this.userRepository.AddAsync(user, cancellationToken).ConfigureAwait(false);
        return Outcome<User>.Success(user);
    }
}

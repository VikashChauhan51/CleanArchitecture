// <copyright file="ProfileQueryHandler.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Abstractions.Repositories;
using MediatorForge.Queries;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.UseCases.Profile;

internal sealed class ProfileQueryHandler : IQueryHandler<ProfileQuery, Outcome<ProfileResponse>>
{
    private readonly IUserRepository userRepository;
    private readonly ILogger<ProfileQueryHandler> logger;

    public ProfileQueryHandler(
        IUserRepository userRepository,
        ILogger<ProfileQueryHandler> logger)
    {
        this.logger = logger;
        this.userRepository = userRepository;
    }

    public async Task<Outcome<ProfileResponse>> Handle(ProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await this.userRepository.GetByIdAsync(request.UserId, cancellationToken).ConfigureAwait(false);
        if (user is null)
        {
            this.logger.LogInformation("ProfileQueryHandler.Handle: user not found with id: {UserId}", request.UserId);
            return Outcome<ProfileResponse>.NotFound(new OutcomeError("user not found"));
        }

        return Outcome<ProfileResponse>.Success(new ProfileResponse(user.FullName, user.UserName));
    }
}

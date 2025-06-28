using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Abstractions.Providers;

/// <summary>
/// Provides functionality to generate access tokens for users.
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Generates an access token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom to generate the token.</param>
    /// <returns>The generated access token.</returns>
    string AccessToken(User user);
}


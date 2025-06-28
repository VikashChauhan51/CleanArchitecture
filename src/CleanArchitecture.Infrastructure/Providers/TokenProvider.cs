// <copyright file="TokenProvider.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using System.Security.Claims;
using System.Text;
using CleanArchitecture.Abstractions.Configurations;
using CleanArchitecture.Abstractions.Providers;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Infrastructure.Providers;

/// <summary>
/// Provides functionality to generate JWT access tokens for users.
/// </summary>
public sealed class TokenProvider : ITokenProvider
{
    private readonly JwtConfig jwtConfig;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenProvider"/> class.
    /// </summary>
    /// <param name="configuration"></param>
    public TokenProvider(IOptions<JwtConfig> configuration)
    {
        this.jwtConfig = configuration.Value;
    }

    /// <inheritdoc />
    public string AccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtConfig.Key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = this.jwtConfig.Audience,
            Issuer = this.jwtConfig.Issuer,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(this.jwtConfig.TokenLifetimeInHours),
            Subject = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ]),
        };

        return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
    }
}

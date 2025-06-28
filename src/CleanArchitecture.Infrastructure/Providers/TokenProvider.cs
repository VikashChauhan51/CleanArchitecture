using CleanArchitecture.Abstractions.Configurations;
using CleanArchitecture.Abstractions.Providers;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Infrastructure.Providers;

/// <summary>
/// Provides functionality to generate JWT access tokens for users.
/// </summary>
public sealed class TokenProvider : ITokenProvider
{
    private readonly JwtConfig jwtConfig;
    public TokenProvider(IOptions<JwtConfig> configuration)
    {
        jwtConfig = configuration.Value;
    }

    /// <inheritdoc />
    public string AccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = jwtConfig.Audience,
            Issuer = jwtConfig.Issuer,
            IssuedAt = DateTime.UtcNow,
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(jwtConfig.TokenLifetimeInHours),
            Subject = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        ])
        };

        return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
    }
}

namespace CleanArchitecture.Abstractions.Configurations;

/// <summary>
/// Represents configuration options for JWT authentication.
/// </summary>
public sealed class JwtConfig
{
    /// <summary>
    /// The secret key used to sign the JWT.
    /// </summary>
    public string Key { get; init; } = string.Empty;

    /// <summary>
    /// The issuer of the JWT.
    /// </summary>
    public string Issuer { get; init; } = string.Empty;

    /// <summary>
    /// The audience for the JWT.
    /// </summary>
    public string Audience { get; init; } = string.Empty;

    /// <summary>
    /// The lifetime of the token in hours.
    /// </summary>
    public int TokenLifetimeInHours { get; init; } = 24;
}

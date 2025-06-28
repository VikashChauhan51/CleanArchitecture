// <copyright file="JwtConfig.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Abstractions.Configurations;

/// <summary>
/// Represents configuration options for JWT authentication.
/// </summary>
public sealed class JwtConfig
{
    /// <summary>
    /// Gets the secret key used to sign the JWT.
    /// </summary>
    public string Key { get; init; } = string.Empty;

    /// <summary>
    /// Gets the issuer of the JWT.
    /// </summary>
    public string Issuer { get; init; } = string.Empty;

    /// <summary>
    /// Gets the audience for the JWT.
    /// </summary>
    public string Audience { get; init; } = string.Empty;

    /// <summary>
    /// Gets the lifetime of the token in hours.
    /// </summary>
    public int TokenLifetimeInHours { get; init; } = 24;
}

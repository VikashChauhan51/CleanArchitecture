// <copyright file="IPasswordHasher.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

namespace CleanArchitecture.Abstractions.Services;

/// <summary>
/// Provides methods for hashing and verifying passwords.
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Hashes the specified password.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>The hashed password.</returns>
    string HashPassword(string password);

    /// <summary>
    /// Verifies a hashed password against a provided password.
    /// </summary>
    /// <param name="hashedPassword">The previously hashed password.</param>
    /// <param name="providedPassword">The password provided for verification.</param>
    /// <returns>True if the password matches the hash; otherwise, false.</returns>
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}

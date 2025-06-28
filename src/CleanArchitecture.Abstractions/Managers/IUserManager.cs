// <copyright file="IUserManager.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Abstractions.Models;
using CleanArchitecture.Domain.Entities;
using ResultifyCore;

namespace CleanArchitecture.Abstractions.Managers;

/// <summary>
/// Manager interface for user authentication and registration operations.
/// </summary>
public interface IUserManager
{
    /// <summary>
    /// Signs in a user asynchronously.
    /// </summary>
    /// <param name="userName">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An outcome containing a token or error message.</returns>
    Task<Outcome<string>> SignInAsync(string userName, string password, CancellationToken cancellationToken);

    /// <summary>
    /// Signs up a new user asynchronously.
    /// </summary>
    /// <param name="signUpModel">The sign-up model containing user details.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An outcome containing the created user or error information.</returns>
    Task<Outcome<User>> SignUpAsync(SignUpModel signUpModel, CancellationToken cancellationToken);
}

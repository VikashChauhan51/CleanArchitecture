// <copyright file="User.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Represents a user entity in the system.
/// </summary>
public sealed class User : Entity<Guid>
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// Gets or sets the password hash of the user.
    /// </summary>
    public required string PasswordHash { get; set; }
}

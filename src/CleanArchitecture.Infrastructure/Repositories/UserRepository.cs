// <copyright file="UserRepository.cs" company="Clean Architecture">
// Copyright (c) Clean Architecture. All rights reserved.
// </copyright>

using CleanArchitecture.Abstractions.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for user-related data operations.
/// </summary>
public sealed class UserRepository(ApplicationDbContext context) : Repository<User, Guid>(context), IUserRepository
{
    /// <inheritdoc />
    public Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        return this.Context.Users.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
    }
}

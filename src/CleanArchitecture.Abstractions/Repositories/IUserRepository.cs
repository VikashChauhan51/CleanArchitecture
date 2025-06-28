using CleanArchitecture.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Abstractions.Repositories;

/// <summary>
/// Repository interface for user-related data operations.
/// </summary>
public interface IUserRepository : IRepositoryAsync<User, Guid>
{
    /// <summary>
    /// Retrieves a user by their username asynchronously.
    /// </summary>
    /// <param name="userName">The username of the user.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The user entity if found; otherwise, null.</returns>
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
}

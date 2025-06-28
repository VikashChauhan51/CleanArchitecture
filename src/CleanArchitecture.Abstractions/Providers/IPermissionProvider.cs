namespace CleanArchitecture.Abstractions.Providers;

/// <summary>
/// Provides user permission retrieval functionality.
/// </summary>
/// <typeparam name="TKey">The type of the user identifier.</typeparam>
public interface IPermissionProvider<TKey>
{
    /// <summary>
    /// Gets the set of permissions for a user by their identifier asynchronously.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <returns>A read-only set of permission strings.</returns>
    Task<IReadOnlySet<string>> GetForUserIdAsync(TKey userId);
}

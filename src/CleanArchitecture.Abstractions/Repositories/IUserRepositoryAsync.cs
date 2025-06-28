using CleanArchitecture.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Abstractions.Repositories;
public interface IUserRepositoryAsync : IRepositoryAsync<User, Guid>
{
    Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
}

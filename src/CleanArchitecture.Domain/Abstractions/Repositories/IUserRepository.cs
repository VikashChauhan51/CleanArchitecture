using CleanArchitecture.Domain.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Domain.Abstractions.Repositories;
public interface IUserRepository : IRepository<User, Guid>, IRepositoryAsync<User, Guid>
{
  Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
}

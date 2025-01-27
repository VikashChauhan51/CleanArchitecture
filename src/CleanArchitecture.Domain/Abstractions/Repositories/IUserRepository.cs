using CleanArchitecture.Domain.Abstractions.Repositories.Core;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Domain.Abstractions.Repositories;
public interface IUserRepository : IRepository<User, long>, IRepositoryAsync<User, long>
{
}

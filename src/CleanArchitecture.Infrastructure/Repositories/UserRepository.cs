using CleanArchitecture.Domain.Abstractions.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Core;


namespace CleanArchitecture.Infrastructure.Repositories;
public sealed class UserRepository(ApplicationDbContext context) : Repository<User, long>(context), IUserRepository
{
}

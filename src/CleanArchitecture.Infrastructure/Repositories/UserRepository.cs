using CleanArchitecture.Domain.Abstractions.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace CleanArchitecture.Infrastructure.Repositories;
public sealed class UserRepository(ApplicationDbContext context) : Repository<User, Guid>(context), IUserRepository
{
    public Task<User?> GetByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
    }
}

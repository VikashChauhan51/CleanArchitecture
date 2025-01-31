using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Entities;

public sealed class User : Entity<Guid>
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
}

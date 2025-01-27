using CleanArchitecture.Domain.Core;

namespace CleanArchitecture.Domain.Entities;

public sealed class User : Entity<long>
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
}

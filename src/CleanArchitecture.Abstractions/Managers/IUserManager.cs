using CleanArchitecture.Abstractions.Models;
using CleanArchitecture.Domain.Entities;
using ResultifyCore;

namespace CleanArchitecture.Abstractions.Managers;
public interface IUserManager
{
    Task<Outcome<string>> SignInAsync(string userName, string password, CancellationToken cancellationToken);
    Task<Outcome<User>> SignUpAsync(SignUpModel signUpModel, CancellationToken cancellationToken);
}

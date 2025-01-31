using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Models;
using ResultifyCore;

namespace CleanArchitecture.Domain.Abstractions.Managers;
public interface IUserManager
{
    Task<Outcome<string>> SignInAsync(string userName, string password, CancellationToken cancellationToken);
    Task<Outcome<User>> SignUpAsync(SignUpModel signUpModel, CancellationToken cancellationToken);
}

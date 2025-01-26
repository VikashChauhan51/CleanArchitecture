namespace CleanArchitecture.Domain.Abstractions.Services.Authentication;
public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Abstractions.Providers;
public interface ITokenProvider
{
    string AccessToken(User user);
}


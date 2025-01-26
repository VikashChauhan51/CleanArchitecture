using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Abstractions.Providers.Authentication;
public interface ITokenProvider
{
    string AccessToken(User user);
}

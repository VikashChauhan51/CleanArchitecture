
namespace CleanArchitecture.Domain.Abstractions.Providers.Authorization;
public interface IPermissionProvider<TKey>
{
    Task<IReadOnlySet<string>> GetForUserIdAsync(TKey userId);
}

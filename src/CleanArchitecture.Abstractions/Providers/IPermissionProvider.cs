namespace CleanArchitecture.Abstractions.Providers;
public interface IPermissionProvider<TKey>
{
    Task<IReadOnlySet<string>> GetForUserIdAsync(TKey userId);
}

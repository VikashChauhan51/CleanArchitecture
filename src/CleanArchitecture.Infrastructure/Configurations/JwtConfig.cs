namespace CleanArchitecture.Infrastructure.Configurations;
public sealed class JwtConfig
{
    public string Key { get; init; } = string.Empty;
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public int TokenLifetimeInHours { get; init; } = 24;
}


using CleanArchitecture.Abstractions.Managers;
using CleanArchitecture.Abstractions.Providers;
using CleanArchitecture.Abstractions.Repositories;
using CleanArchitecture.Abstractions.Services;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Managers;
using CleanArchitecture.Infrastructure.Providers;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Infrastructure;
public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<ITimeProvider, DateTimeProvider>();
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepositoryAsync, UserRepository>();
        services.AddScoped<IUserManager, UserManager>();

        return services;
    }

}

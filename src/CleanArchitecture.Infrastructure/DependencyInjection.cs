using CleanArchitecture.Domain.Abstractions.Managers;
using CleanArchitecture.Domain.Abstractions.Providers;
using CleanArchitecture.Domain.Abstractions.Providers.Authentication;
using CleanArchitecture.Domain.Abstractions.Repositories;
using CleanArchitecture.Domain.Abstractions.Services.Authentication;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Managers;
using CleanArchitecture.Infrastructure.Providers;
using CleanArchitecture.Infrastructure.Providers.Authentication;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Infrastructure;
public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

#if (SqlServer)
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
#elif (PostgreSQL)
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
#endif

        services.AddScoped<ITimeProvider, DateTimeProvider>();
        services.AddScoped<ITokenProvider, TokenProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserManager, UserManager>();

        return services;
    }

}

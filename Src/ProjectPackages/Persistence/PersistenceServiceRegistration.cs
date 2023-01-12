using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.ServiceRegistrations;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddDbContext<PostgreLrmsDbContext>(options => {
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreLRMSConnectionString")).UseSnakeCaseNamingConvention();
        });

        services.AddDbContext<PostgreLrmsUserDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreLRMSUserConnectionString")).UseSnakeCaseNamingConvention();
        });
                
        services.AddLRMSUserRegistration();
        services.AddLRMSMainRegistration();
        
        return services;
    }
}

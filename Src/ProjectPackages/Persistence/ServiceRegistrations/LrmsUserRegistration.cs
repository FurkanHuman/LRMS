using Application.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.ServiceRegistrations;

public static class LrmsUserRegistration
{
    public static IServiceCollection AddLRMSUserRegistration(this IServiceCollection services)
    {
        // LRMS User 

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IPasswordRepository, PasswordRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        return services;
    }
}

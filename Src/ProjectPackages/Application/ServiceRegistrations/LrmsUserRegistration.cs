using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.OperationClaimService;
using Application.Services.PasswordService;
using Application.Services.RefreshTokenService;
using Application.Services.UserOperationClaimService;
using Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.ServiceRegistrations;

public static class LrmsUserRegistration
{
    public static IServiceCollection AddLRMSUserRegistration(this IServiceCollection services)
    {
        // LRMS User 

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<AuthBusinessRules>();
        
        services.AddScoped<IPasswordService, PasswordManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IPasswordService, PasswordManager>();
        services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IUserService, UserManager>();

        return services;
    }
}

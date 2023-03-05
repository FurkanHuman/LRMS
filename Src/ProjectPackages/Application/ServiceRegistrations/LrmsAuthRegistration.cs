using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.EmailAuthenticatorService;
using Application.Services.OperationClaimService;
using Application.Services.OtpAuthenticatorService;
using Application.Services.PasswordService;
using Application.Services.RefreshTokenService;
using Application.Services.UserOperationClaimService;
using Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.ServiceRegistrations;

public static class LrmsAuthRegistration
{
    public static IServiceCollection AddLRMSUserRegistration(this IServiceCollection services)
    {
        // LRMS User & Auth
        
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IPasswordService, PasswordManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IOtpAuthenticatorService, OtpAuthenticatorManager>();
        services.AddScoped<IEmailAuthenticatorService, EmailAuthenticatorManager>();
        services.AddScoped<IPasswordService, PasswordManager>();
        services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IUserService, UserManager>();

        return services;
    }
}

using Application.ServiceRegistrations;
using Application.Services.ServiceRegistrations;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            //configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            //configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddCoreServices();
        services.AddLrmsInfoRegistration();
        services.AddLrmsIntermediateTablesRegistration();
        services.AddLRMSMainRegistration();
        services.AddLRMSUserRegistration();

        return services;
    }
}
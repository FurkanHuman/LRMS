using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.ElasticSearch;
using Core.Mailing.MailKitImplementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Mailing;

namespace Application.ServiceRegistrations;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices( this IServiceCollection services)
    {
        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();

        return services;
    }
}

using CNX.LogService.Business.Classes;
using CNX.LogService.Business.Interfaces;
using CNX.LogService.Business.Utils;
using CNX.LogService.Data.Classes;
using CNX.LogService.Data.Interfaces;
using CNX.LogService.Data.Classes.Base;
using CNX.LogService.Data.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CNX.LogService.WebApi
{
    public static class DependencyInjection
    {
        public static void Load(IServiceCollection services)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            RepositoryInjection(services);
            BusinessInjection(services);
        }

        private static void BusinessInjection(IServiceCollection services)
        {
            services.AddTransient<ILogBusiness, LogBusiness>();
        }

        private static void RepositoryInjection(IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();
        }
    }
}

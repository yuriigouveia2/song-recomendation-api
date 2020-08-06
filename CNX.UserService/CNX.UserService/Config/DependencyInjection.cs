using CNX.UserService.Business.Classes;
using CNX.UserService.Business.Interfaces;
using CNX.UserService.Business.Utils;
using CNX.UserService.Repository.Classes;
using CNX.UserService.Repository.Classes.Base;
using CNX.UserService.Repository.Interfaces;
using CNX.UserService.Repository.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CNX.UserService.WebApi
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
            services.AddTransient<IUserBusiness, UserBusiness>();
        }

        private static void RepositoryInjection(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

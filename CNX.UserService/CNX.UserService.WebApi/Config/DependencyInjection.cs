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

using CNX.WeatherService.Business.Classes;
using CNX.WeatherService.Business.Interfaces;
using CNX.WeatherService.Business.Util;
using CNX.WeatherService.Data.Classes.Base;
using CNX.WeatherService.Data.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.WeatherService.Config
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
            services.AddTransient<IWeatherBusiness, WeatherBusiness>();
            services.AddTransient<IMusicRecomendationBusiness, MusicRecomendationBusiness>();
        }

        private static void RepositoryInjection(IServiceCollection services)
        {
            
        }
    }
}

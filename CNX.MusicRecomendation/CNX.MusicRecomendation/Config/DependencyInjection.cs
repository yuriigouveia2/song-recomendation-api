using CNX.MusicRecomendation.Business.Classes;
using CNX.MusicRecomendation.Business.Interfaces;
using CNX.MusicRecomendation.Business.Util;
using CNX.MusicRecomendation.Data.Classes.Base;
using CNX.MusicRecomendation.Data.Interfaces.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.MusicRecomendation.Config
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

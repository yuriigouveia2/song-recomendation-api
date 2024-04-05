using CNX.WeatherService.Model.Entities;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.WeatherService.Business.Interfaces
{
    public interface IWeatherBusiness
    {
        Task<FullPlaylist> RecomendMusicByCityId(int cityId);
    }
}

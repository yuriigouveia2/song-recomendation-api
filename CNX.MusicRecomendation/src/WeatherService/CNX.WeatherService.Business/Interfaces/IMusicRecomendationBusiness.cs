using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.WeatherService.Business.Interfaces
{
    public interface IMusicRecomendationBusiness
    {
        Task<FullPlaylist> RecomendMusicByCityTemperature(double temp);
    }
}

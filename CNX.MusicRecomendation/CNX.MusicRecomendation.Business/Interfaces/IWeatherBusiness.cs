using CNX.MusicRecomendation.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.MusicRecomendation.Business.Interfaces
{
    public interface IWeatherBusiness
    {
        Task<CityWeatherResponse> RecomendMusicByCityId(int cityId);
    }
}

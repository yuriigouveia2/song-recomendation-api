using AutoMapper;
using CNX.WeatherService.Business.Classes.Base;
using CNX.WeatherService.Business.Interfaces;
using CNX.WeatherService.Business.Util;
using CNX.WeatherService.Model.Entities;
using Newtonsoft.Json;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CNX.WeatherService.Business.Classes
{
    public class WeatherBusiness : BaseBusiness, IWeatherBusiness
    {
        private readonly IMapper _mapper;
        private readonly IMusicRecomendationBusiness _musicRecomendationBusiness;
       
        public WeatherBusiness(IMapper mapper, INotifier notifier, IMusicRecomendationBusiness musicRecomendationBusiness) : base(notifier)
        {
            _mapper = mapper;
            _musicRecomendationBusiness = musicRecomendationBusiness;
        }

        public async Task<FullPlaylist> RecomendMusicByCityId(int cityId)
        {
            var cityWeatherResponse = await requestWeatherInformationByCityId(cityId);
            if (cityWeatherResponse == null || cityWeatherResponse.StatusCode != 200)
            {
                Notify("It was not possible to get weather information, try again later.");
                return null;
            }
            
            return await _musicRecomendationBusiness.RecomendMusicByCityTemperature(cityWeatherResponse.Weather.TemperatureCelsius);
        }

        private const string _openWeatherApiUri = "http://api.openweathermap.org";
        private const string _openWeatherApiId = "ec54963e1337381c82e762136bc1eef1";
        private async Task<CityWeatherResponse> requestWeatherInformationByCityId(int cityId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_openWeatherApiUri);
                    var response = await client.GetAsync($"/data/2.5/weather?id={cityId}&appid={_openWeatherApiId}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var cityWeatherResponseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CityWeatherResponse>(cityWeatherResponseJson);
                }
                catch
                {
                    Notify("It was not possible to contact Open Weather API.");
                    return null;
                }
            }
        }
    }
}

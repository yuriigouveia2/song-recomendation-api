using AutoMapper;
using CNX.MusicRecomendation.Business.Classes.Base;
using CNX.MusicRecomendation.Business.Interfaces;
using CNX.MusicRecomendation.Business.Util;
using CNX.MusicRecomendation.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CNX.MusicRecomendation.Business.Classes
{
    public class WeatherBusiness : BaseBusiness, IWeatherBusiness
    {
        private readonly IMapper _mapper;
       
        public WeatherBusiness(IMapper mapper, INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
        }

        public async Task<CityWeatherResponse> RecomendMusicByCityId(int cityId)
        {
            var cityWeatherResponse = await requestWeatherInformationByCityId(cityId);
            if (cityWeatherResponse == null || cityWeatherResponse.StatusCode != 200)
            {
                Notify("It was not possible to get weather information, try again later.");
                return null;
            }
            
            return cityWeatherResponse;
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

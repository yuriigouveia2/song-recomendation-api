using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CNX.WeatherService.Model.Entities
{
    public class CityWeatherResponse
    {
        [JsonProperty("cod")]
        public int StatusCode { get; set; }

        [JsonProperty("id")]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("main")]
        public Weather Weather { get; set; }
    }
}

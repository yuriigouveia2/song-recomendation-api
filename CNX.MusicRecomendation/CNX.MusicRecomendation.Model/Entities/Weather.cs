using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.MusicRecomendation.Model.Entities
{
    public class Weather
    {
        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("temp")]
        public double TemperatureCelsius { get; set; }
    }
}

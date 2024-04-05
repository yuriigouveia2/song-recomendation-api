using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.WeatherService.Model.Entities
{
    public class UserResponse
    {
        [JsonProperty("data")]
        public User Data { get; set; }
    }
}

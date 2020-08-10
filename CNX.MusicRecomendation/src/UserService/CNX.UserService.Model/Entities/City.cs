using CNX.UserService.Model.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Model.Entities
{
    public class City
    {
        [JsonProperty("id")]
        public float Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

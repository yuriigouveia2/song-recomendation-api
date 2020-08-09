﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.MusicRecomendation.Model.Entities
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresInSeconds { get; set; }

    }
}

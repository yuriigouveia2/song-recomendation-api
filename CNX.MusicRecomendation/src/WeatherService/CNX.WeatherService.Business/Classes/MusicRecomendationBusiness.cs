using AutoMapper;
using CNX.WeatherService.Business.Classes.Base;
using CNX.WeatherService.Business.Interfaces;
using CNX.WeatherService.Business.Util;
using CNX.WeatherService.Model.Entities;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CNX.WeatherService.Business.Classes
{
    public class MusicRecomendationBusiness : BaseBusiness, IMusicRecomendationBusiness
    {
        public const string _clientId = "527678fbb4464ae0bd449bb4243a674f";
        public const string _clientSecret = "ec4fe9b215a24a93a577a19822f31857";

        public MusicRecomendationBusiness(INotifier notifier) : base(notifier)
        {
            
        }

        public async Task<FullPlaylist> RecomendMusicByCityTemperature(double temp)
        {
            var token = await getSpotifyToken();
            if (token.IsExpired())
                token = await getSpotifyToken();

            var trackRecomendation = await findTrackByTemp(token, temp);
            if (trackRecomendation == null || trackRecomendation.Error != null)
            {
                Notify("It was not possible to connect to Spotify Web API, try again later.");
                return null;
            }
            return trackRecomendation;
        }

        private const string _partyPlaylistId = "37i9dQZF1DX8FwnYE6PRvL";
        private const string _popPlaylistId = "37i9dQZF1DX1ngEVM0lKrb";
        private const string _classicalPlaylistId = "37i9dQZF1DWWEJlAGA9gs0";
        private async Task<FullPlaylist> findTrackByTemp(Token token, double temp)
        {
            var spotify = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };

            if (temp > 30)
                return await spotify.GetPlaylistAsync(_partyPlaylistId);

            else if (temp >=15 && temp <= 30)
                return await spotify.GetPlaylistAsync(_popPlaylistId);

            else
                return await spotify.GetPlaylistAsync(_classicalPlaylistId);
        }

        private async Task<Token> getSpotifyToken()
        {
            var req = new CredentialsAuth(_clientId, _clientSecret);
            return await req.GetToken();
        }
    }
}

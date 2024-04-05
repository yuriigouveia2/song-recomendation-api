using AutoMapper;
using CNX.UserService.Model;
using CNX.WeatherService.Business.Interfaces;
using CNX.WeatherService.Business.Util;
using CNX.WeatherService.Model.Entities;
using CNX.WeatherService.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CNX.WeatherService.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/music-recomendation/[controller]")]
    [ApiController]
    public class WeatherController : MainController
    {
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;
        private readonly IWeatherBusiness _weatherBusiness;
        private readonly IMusicRecomendationBusiness _musicRecomendationBusiness;
        private bool locked;
        public WeatherController(IMapper mapper, 
                                INotifier notifier, 
                                IWeatherBusiness weatherBusiness,
                                IMusicRecomendationBusiness musicRecomendationBusiness) : base(mapper, notifier)
        {
            _mapper = mapper;
            _notifier = notifier;
            _weatherBusiness = weatherBusiness;
            _musicRecomendationBusiness = musicRecomendationBusiness;
            locked = true;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecomendation()
        {
            try
            {
                var user = await validateToken(GetJwtToken());
                while (locked) ;
                if (user == null || user.Id == Guid.Empty)
                {
                    Notify("User not valid, please login into the application with a valid user");
                    return CustomResponse();
                }
                return CustomResponse(await _weatherBusiness.RecomendMusicByCityId(user.HometownId));
            }
            catch (Exception ex)
            {
                Notify("It was not possible to get music recomendation, please contact the support to fix it.", ex?.InnerException?.Message);
                return CustomResponse();
            }
        }

        private async Task<User> validateToken(string jwt)
        {
            var httpClient = HttpClientFactory.Create();
            var validateJwtUrl = $"http://userservice/api/user-service/user/validate-jwt";
            var request = new HttpRequestMessage(HttpMethod.Get, validateJwtUrl);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {jwt}");

            var httpResponse = await httpClient.SendAsync(request);
            locked = false;
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Notify("It was not possible to conncet to the user service, please contact the support to fix it.");
                return null;
            }
            
            var userStr = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserResponse>(userStr).Data;
        }
    }
}

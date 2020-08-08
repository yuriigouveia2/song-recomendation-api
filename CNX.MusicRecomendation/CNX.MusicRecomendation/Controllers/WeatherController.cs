using AutoMapper;
using CNX.MusicRecomendation.Business.Interfaces;
using CNX.MusicRecomendation.Business.Util;
using CNX.MusicRecomendation.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.MusicRecomendation.WebApi.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [Route("api/music-recomendation/[controller]")]
    [ApiController]
    public class WeatherController : MainController
    {
        private readonly IMapper _mapper;
        private readonly INotifier _notifier;
        private readonly IWeatherBusiness _weatherBusiness;
        public WeatherController(IMapper mapper, INotifier notifier, IWeatherBusiness weatherBusiness) : base(mapper, notifier)
        {
            _mapper = mapper;
            _notifier = notifier;
            _weatherBusiness = weatherBusiness;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecomendation([FromQuery] int cityId)
        {
            try
            {
                return CustomResponse(await _weatherBusiness.RecomendMusicByCityId(cityId));
            }
            catch (Exception ex)
            {
                Notify("It was not possible to get music recomendation.", ex?.InnerException?.Message);
                return CustomResponse();
            }
        }
    }
}

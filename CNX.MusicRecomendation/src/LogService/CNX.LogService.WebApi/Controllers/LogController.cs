using System;
using System.Threading.Tasks;
using CNX.LogService.Business.Interfaces;
using CNX.LogService.Business.Utils;
using CNX.LogService.Model.Entities;
using CNX.LogService.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CNX.UserService.WebApi.Controllers
{
    [Route("api/log-service/[controller]")]
    [ApiController]
    public class LogController : MainController
    {
        private readonly ILogBusiness _logBusiness;

        public LogController(ILogBusiness logBusiness,
                              
                              INotifier notifier) : base(notifier)
        {
            _logBusiness = logBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Log log) 
        {
            try
            {
                await _logBusiness.Create(log);
                return CustomResponse("Log saved.");
            }
            catch (Exception ex)
            {
                Notify("An error ocurred while creating a log, please contact the support to fix it.", ex?.InnerException?.Message);
                return CustomResponse();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CNX.UserService.Business.Interfaces;
using CNX.UserService.Business.Utils;
using CNX.UserService.Model;
using CNX.UserService.Model.Dtos.User;
using CNX.UserService.Model.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CNX.UserService.WebApi.Controllers
{
    [Route("api/user-service/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly UserManager<User> _userMananger;
        private readonly IUserBusiness _userBusiness;
        private readonly SignInManager<User> _signInMananger;
        private HttpClient _client;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public UserController(IUserBusiness userBusiness,
                              UserManager<User> userMananger,
                              SignInManager<User> signInMananger,
                              IOptions<AppSettings> appSettings,
                              IMapper mapper,
                              INotifier notifier) : base(mapper, notifier)
        {
            _client = new HttpClient();
            _appSettings = appSettings.Value;
            _userBusiness = userBusiness;
            _userMananger = userMananger;
            _signInMananger = signInMananger;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                
                return CustomResponse(await _userBusiness.Create(userDto));
            }
            catch (Exception ex)
            {
                Notify("An error ocurred while creating an user.", ex?.InnerException?.Message);
                return CustomResponse();
            }
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);
                return CustomResponse(await _userBusiness.Login(login));               
            }
            catch (Exception e)
            {
                Notify("Error while logging in.", e.InnerException?.Message);
                return CustomResponse();
            }
        }
    }
}
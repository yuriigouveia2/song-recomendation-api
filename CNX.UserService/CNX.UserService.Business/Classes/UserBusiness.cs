using AutoMapper;
using CNX.UserService.Business.Interfaces;
using CNX.UserService.Business.Utils;
using CNX.UserService.Model.Dtos.User;
using CNX.UserService.Data.Interfaces;
using CNX.UserService.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using Microsoft.AspNetCore.Identity;
using CNX.UserService.Business.Classes.Services;

namespace CNX.UserService.Business.Classes
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInMananger;

        public UserBusiness(IUserRepository userRepository,
                            IMapper mapper,
                            INotifier notifier,
                            IOptions<AppSettings> appSettings,
                            UserManager<User> userManager,
                            SignInManager<User> signInMananger) : base(notifier)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpClient = new HttpClient();
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInMananger = signInMananger;
        }

        public async Task<string> Create(UserDto userDto)
        {
            if (IsUserRegistered(userDto))
            {
                return null;
            }

            var hometown = _userRepository.FindCity(userDto);
            if (hometown == null)
            {
                Notify("It was not possible to identify the hometown, please enter a valid one.");
                return null;
            }

            var user = ConvertUserDtoToEntity(userDto, hometown);

            var userCreated = await _userManager.CreateAsync(user, userDto.Password);
            if (userCreated.Succeeded)
            {
                return "User created successfully.";
            }
            else
            {
                Notify("Error while creating user.");
                return null;
            }
        }

        private User ConvertUserDtoToEntity(UserDto userDto, City hometown)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Cpf = userDto.Cpf.ToString(),
                UserName = userDto.Cpf.ToString(),
                Email = userDto.Email.ToString(),
                Name = userDto.Name,
                Deleted = false,
                NormalizedEmail = userDto.Email.ToUpper(),
                NormalizedUserName = userDto.Name,
                CreatedAt = DateTime.Now,
                HometownId = Convert.ToInt32(hometown.Id)                
            };
        }

        private bool IsUserRegistered(UserDto userDto)
        {
            if (CheckCpf(userDto.Cpf))
            {
                Notify("CPF already registered.");
                return true;
            }
            else if (CheckEmail(userDto.Email))
            {
                Notify("E-mail already registered.");
                return true;
            }
            return false;
        }

        private bool CheckCpf(Cpf cpf) => _userRepository.IsCpfRegistered(cpf);

        private bool CheckEmail(Email email) => _userRepository.IsEmailRegistered(email);

        public async Task<LoginResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Cpf.ToString());
            var signInResult = await _signInMananger.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);
            
            if (!signInResult.Succeeded)
            {
                Notify("It was not possible to authenticate to the server.");
                return null;
            }
            var userLoginDto = _mapper.Map<UserLoginDto>(user);
            var token = userLoginDto.GenerateToken(_appSettings);

            return new LoginResult(userLoginDto, token);
        }

        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserDto GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}

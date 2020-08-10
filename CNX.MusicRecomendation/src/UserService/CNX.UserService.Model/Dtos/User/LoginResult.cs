using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Model.Dtos.User
{
    public class LoginResult
    {
        public UserLoginDto UserLogged { get; set; }
        public string Token { get; set; }

        public LoginResult(UserLoginDto userLoginDto, string token)
        {
            UserLogged = userLoginDto;
            Token = token;
        }
    }
}

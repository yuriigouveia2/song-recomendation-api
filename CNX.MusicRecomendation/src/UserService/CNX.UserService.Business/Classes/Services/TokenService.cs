using CNX.UserService.Model;
using CNX.UserService.Model.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CNX.UserService.Business.Classes.Services
{
    public static class TokenService
    {
        public static string GenerateToken(this UserLoginDto user, AppSettings appSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Cpf.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(appSettings.ExpireInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            return tokenHandler
                .WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}

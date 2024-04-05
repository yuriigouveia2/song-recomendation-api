using CNX.UserService.Model.Dtos.User;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CNX.UserService.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<string> Create(UserDto userDto);
        UserDto GetbyId(Guid id);
        bool Delete(Guid userId);
        bool Update(Guid id, UserDto userDto);
        Task<LoginResult> Login(LoginDto login);
        User GetbyCpf(string cpf);
        object ValidateJwt(User user);
    }
}

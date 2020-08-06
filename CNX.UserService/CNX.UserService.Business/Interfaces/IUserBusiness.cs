using CNX.UserService.Model.DTOs.Usuario;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Business.Interfaces
{
    public interface IUserBusiness
    {
        UserDto GetbyId(Guid id);
        bool Delete(Guid userId);
        bool Update(Guid id, UserDto userDto);
    }
}

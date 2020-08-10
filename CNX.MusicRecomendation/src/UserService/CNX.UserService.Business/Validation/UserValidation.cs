using CNX.UserService.Business.Classes;
using CNX.UserService.Model.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Business.Validation
{
    public static class UserValidation
    {
        public static bool IsValid(this UserDto userDto)
        {
            if (!isCityValid(userDto.Hometown))
            {
                return false;
            }

            return true;
        }

        private static bool isCityValid(string hometown)
        {
            return true;
        }
    }
}

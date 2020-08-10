using CNX.UserService.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Model.Dtos.User
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
    }
}

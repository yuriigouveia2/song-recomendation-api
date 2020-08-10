using CNX.UserService.Model.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CNX.UserService.Model.Dtos.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Cpf Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}

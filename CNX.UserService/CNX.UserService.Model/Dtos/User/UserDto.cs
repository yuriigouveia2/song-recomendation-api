using CNX.UserService.Model.Types;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CNX.UserService.Model.Dtos.User
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Cpf Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Email Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted { get; set; }
    }
}

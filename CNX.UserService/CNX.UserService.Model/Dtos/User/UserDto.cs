using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CNX.UserService.Model.DTOs.Usuario
{
    public class UserDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //public string CPF { set { Cpf = value; } }
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool PrimeiroAcesso { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}

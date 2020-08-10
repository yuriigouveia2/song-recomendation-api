using CNX.UserService.Model.Types;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CNX.UserService.Model.Dtos.User
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Cpf Cpf { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Email Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and lesser than 20 characters.")]
        public string Hometown { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Deleted { get; set; }
    }
}

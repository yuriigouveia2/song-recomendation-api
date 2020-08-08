using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CNX.UserService.Model.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public bool Deleted { get; set; }
        public int HometownId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<PersonalNote> PersonalNotes { get; set; }

        public User()
        {
            PersonalNotes = new List<PersonalNote>();
        }
    }
}

using CNX.UserService.Model.Entities.Base;
using System;

namespace CNX.UserService.Model.Entities
{
    public class PersonalNote : BaseEntity
    {
        public string Note { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}

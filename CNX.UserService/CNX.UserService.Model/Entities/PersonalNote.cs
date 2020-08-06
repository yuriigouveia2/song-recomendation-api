using CNX.UserService.Model.Entities.Base;

namespace CNX.UserService.Model.Entities
{
    public class PersonalNote : BaseEntity
    {
        public string Note { get; set; }

        public virtual User User { get; set; }
    }
}

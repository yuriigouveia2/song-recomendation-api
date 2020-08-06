using CNX.UserService.Model.Entities;
using System;
using System.Linq;

namespace CNX.UserService.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetQuery();
        void Update(Guid id, User User);
        User GetById(Guid id);
        void Delete(Guid id);

    }
}

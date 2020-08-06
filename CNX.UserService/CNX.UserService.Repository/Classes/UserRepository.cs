using System;
using System.Linq;
using CNX.UserService.Repository.DataContext;
using CNX.UserService.Repository.Interfaces;
using CNX.UserService.Model.Entities;

namespace CNX.UserService.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetQuery()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, User User)
        {
            throw new NotImplementedException();
        }
    }
}

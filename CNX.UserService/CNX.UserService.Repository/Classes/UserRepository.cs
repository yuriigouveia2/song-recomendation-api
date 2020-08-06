using System;
using System.Linq;
using CNX.UserService.Repository.DataContext;
using CNX.UserService.Repository.Interfaces;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System.Threading.Tasks;
using System.Transactions;

namespace CNX.UserService.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public bool CheckCpf(Cpf cpf) => _context.Users.Any(prop => prop.Cpf.Equals(cpf.ToString()));

        public bool CheckEmail(Email email) => _context.Users.Any(prop => prop.Email.ToUpper().Equals(email.ToUpper()));

        public void Create(User user)
        {
            try
            {
                using(var scope = new TransactionScope())
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    scope.Complete();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetByCpf(Cpf cpf) => _context.Users.FirstOrDefault(x => x.Cpf.Equals(cpf.ToString()));
        public User GetByEmail(Email email) => _context.Users.FirstOrDefault(x => x.Email.Equals(email.ToString()));

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

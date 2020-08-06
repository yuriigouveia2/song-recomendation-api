using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.UserService.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetQuery();
        void Update(Guid id, User User);
        User GetById(Guid id);
        void Delete(Guid id);
        void Create(User user); 
        bool CheckCpf(Cpf cpf);
        bool CheckEmail(Email email);
        User GetByCpf(Cpf cpf);
        User GetByEmail(Email email);
    }
}

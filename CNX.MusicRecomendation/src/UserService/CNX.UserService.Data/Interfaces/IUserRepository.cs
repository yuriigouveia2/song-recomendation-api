using CNX.UserService.Model.Dtos.User;
using CNX.UserService.Model.Entities;
using CNX.UserService.Model.Types;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CNX.UserService.Data.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetQuery();
        void Update(Guid id, User User);
        User GetById(Guid id);
        void Delete(Guid id);
        void Create(User user); 
        bool IsCpfRegistered(Cpf cpf);
        bool IsEmailRegistered(Email email);
        User GetByCpf(Cpf cpf);
        User GetByEmail(Email email);
        City FindCity(UserDto userDto);
    }
}

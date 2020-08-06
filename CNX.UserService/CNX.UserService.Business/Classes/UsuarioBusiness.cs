using AutoMapper;
using CNX.UserService.Business.Classes;
using CNX.UserService.Business.Interfaces;
using CNX.UserService.Business.Utils;
using CNX.UserService.Model.DTOs.Usuario;
using CNX.UserService.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNX.UserService.Business.Classes
{
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public UserBusiness(IUserRepository UserRepository, IMapper mapper, INotifier notifier) : base(notifier)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
        }

        public bool Delete(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserDto GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}

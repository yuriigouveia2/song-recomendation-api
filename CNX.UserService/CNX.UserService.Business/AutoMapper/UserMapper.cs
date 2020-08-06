using AutoMapper;
using CNX.UserService.Model.Dtos.User;
using CNX.UserService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.UserService.Business.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>()
                .ReverseMap()
                .ForPath(dest => dest.Cpf, opts => opts.MapFrom(src => src.Cpf.ToString()))
                .ForPath(dest => dest.Email, opts => opts.MapFrom(src => src.Email.ToString()));

            CreateMap<User, UserLoginDto>()
                .ReverseMap()
                .ForPath(dest => dest.Cpf, opts => opts.MapFrom(src => src.Cpf.ToString()))
                .ForPath(dest => dest.Email, opts => opts.MapFrom(src => src.Email.ToString()));
        }
    }
}

﻿using Proiectasp.Models.DTOs;
using Proiectasp.Models;
using AutoMapper;

namespace Proiectasp.Helpers
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(ud => ud.FullName,
                opts => opts.MapFrom(u => u.FirstName + u.LastName));
        }
    }
}

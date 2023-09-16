using AutoMapper;
using HomeFinder.Core.Dto.User;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();             
        }   
    }       
}           
            
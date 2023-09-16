using AutoMapper;
using HomeFinder.Core.Dto.Home;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class HomeProfile:Profile
    {
        public HomeProfile()
        {
            CreateMap<Home,HomeDto>();
            CreateMap<HomeCreateDto,Home>();
            CreateMap<HomeUpdateDto,Home>();
        }
    }
}

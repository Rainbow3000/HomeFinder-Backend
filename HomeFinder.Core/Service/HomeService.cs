using AutoMapper;
using HomeFinder.Core.Dto.Home;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeFinder.Core.Service
{
    public class HomeService : BaseService<Home,HomeDto, HomeCreateDto, HomeUpdateDto>, IHomeService
    {
        private readonly IHomeRepository _homeRepository;
        public HomeService(IHomeRepository homeRepository, IMapper mapper) : base(homeRepository, mapper)
        {
           
        }
    }
}

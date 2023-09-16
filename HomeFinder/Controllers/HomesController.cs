using HomeFinder.Core.Dto.Home;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : BasesController<HomeDto,HomeCreateDto,HomeUpdateDto>
    {
        private readonly IHomeService _homeService;
        private readonly DatabaseContext _databaseContext;
        public HomesController(IHomeService homeService,DatabaseContext databaseContext) : base(homeService)
        {
            _homeService = homeService;
            _databaseContext = databaseContext; 
        }
    }
}

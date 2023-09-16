using HomeFinder.Core.Dto.User;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class UsersController : BasesController<UserDto, UserCreateDto, UserUpdateDto>
    {
        private readonly IUserService _userService;
        private readonly DatabaseContext _databaseContext;
        public UsersController(IUserService userService, DatabaseContext databaseContext) : base(userService)
        {
            _userService = userService;
            _databaseContext = databaseContext;
        }
    }
}

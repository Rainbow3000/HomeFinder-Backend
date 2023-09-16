using AutoMapper;
using HomeFinder.Core.Dto.User;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class UserService : BaseService<User, UserDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        // private readonly IUserRepository _userRepository;
        // private readonly IMapper _mapper; 
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            // _userRepository = userRepository;

        }
    }
}

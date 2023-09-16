using HomeFinder.Core.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Service
{
    public interface IUserService : IBaseService<UserDto, UserCreateDto, UserUpdateDto>
    {

    }
}

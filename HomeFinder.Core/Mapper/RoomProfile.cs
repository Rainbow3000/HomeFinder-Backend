using AutoMapper;
using HomeFinder.Core.Dto.Room;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<RoomCreateDto, Room>();
        }
    }
}

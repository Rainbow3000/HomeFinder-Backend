using AutoMapper;
using HomeFinder.Core.Dto.Room;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class RoomService : BaseService<Room, RoomDto, RoomCreateDto, RoomUpdateDto>, IRoomService
    {
        // private readonly IRoomRepository _roomRepository;
        // private readonly IMapper _mapper; 
        public RoomService(IRoomRepository roomRepository, IMapper mapper) : base(roomRepository, mapper)
        {
            // _roomRepository = roomRepository;

        }
    }
}

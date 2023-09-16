using HomeFinder.Core.Dto.Room;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class RoomsController : BasesController<RoomDto, RoomCreateDto, RoomUpdateDto>
    {
        private readonly IRoomService _roomService;
        private readonly DatabaseContext _databaseContext;
        public RoomsController(IRoomService roomService, DatabaseContext databaseContext) : base(roomService)
        {
            _roomService = roomService;
            _databaseContext = databaseContext;
        }
    }
}

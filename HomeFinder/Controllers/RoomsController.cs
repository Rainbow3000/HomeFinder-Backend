using HomeFinder.Core.DataResponse;
using HomeFinder.Core.Dto.Filter;
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
        public RoomsController(IRoomService roomService, DatabaseContext databaseContext) : base(roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("Filter")]
        public async Task<DataResponse> GetListAsync([FromQuery] RoomFilter filter)
        {
            var entities  = await _roomService.GetListAsync(filter);
            return new DataResponse(entities, StatusCodes.Status200OK); 
        }
    }
}

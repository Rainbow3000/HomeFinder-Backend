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
            var entities = await _roomService.GetListAsync(filter);
            return new DataResponse(entities, StatusCodes.Status200OK);

        }

        [HttpPut("UpdateImage/{id}")]
        public async Task<DataResponse> PutImageAsync(Guid id)
        {
            var rowEffected = await _roomService.UpdateImageAsync(id);
            return new DataResponse(rowEffected, StatusCodes.Status200OK);

        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<DataResponse> PutStatusAsync(Guid id)
        {
            var rowEffected = await _roomService.UpdateStatusAsync(id);
            return new DataResponse(rowEffected, StatusCodes.Status200OK);

        }

        [HttpGet("PageSize")]
        public async Task<DataResponse> PageSizeAsync()
        {
            var pageSize = await _roomService.GetPageSize();
            return new DataResponse(pageSize, StatusCodes.Status200OK);

        }

        [HttpGet("GetByUser/{id}")]
        public async Task<DataResponse> GetByUser(Guid id)
        {
            var data = await _roomService.GetByUser(id);
            return new DataResponse(data, StatusCodes.Status200OK);

        }
    }
}

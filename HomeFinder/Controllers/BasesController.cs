
using HomeFinder.Core.DataResponse;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Filter;
using HomeFinder.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HomeFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : ControllerBase
    {
        private readonly IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseService;
       
        public BasesController(IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService) {
            _baseService  = baseService;
        }

       

        [HttpGet]
       
        public async Task<DataResponse> GetAllAsync()
        {
            var entities = await _baseService.GetAllAsync();
            return new DataResponse(entities,StatusCodes.Status200OK);
        }


        [HttpGet("{id}")]
        public async Task<DataResponse> GetAsync(Guid id) {
            var entity = await _baseService.GetAsync(id);
            return new DataResponse(entity, StatusCodes.Status200OK);
        }
        [HttpPost]
        public async Task<DataResponse> InsertAsync([FromBody] TEntityCreateDto entityCreateDto )
        {
            var entity = await _baseService.InsertAsync(entityCreateDto);
            return  new DataResponse(entity, StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<DataResponse> PutAsync([FromBody] TEntityUpdateDto entityUpdateDto , Guid id)
        {
            var entity = await _baseService.UpdateAsync(entityUpdateDto , id);
            return new DataResponse(entity, StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public async Task<DataResponse> Delete(Guid id)
        {
            await _baseService.DeleteAsync(id);
            return new DataResponse(null, StatusCodes.Status200OK);
        }
    }
}

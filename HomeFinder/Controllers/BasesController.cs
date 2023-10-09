
using HomeFinder.Core.DataResponse;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Filter;
using HomeFinder.Filter.Jwt;
using HomeFinder.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
       
        public virtual async Task<DataResponse> GetAllAsync()
        {
            var entities = await _baseService.GetAllAsync();
            return new DataResponse(entities,StatusCodes.Status200OK);
        }


        [HttpGet("{id}")]
        public virtual async Task<DataResponse> GetAsync(Guid id) {
            var entity = await _baseService.GetAsync(id);
            return new DataResponse(entity, StatusCodes.Status200OK);
        }
        [HttpPost]
        [ServiceFilter(typeof(UserTokenFilter))]
        public virtual async Task<DataResponse> InsertAsync([FromBody] TEntityCreateDto entityCreateDto )
        {
            var entity = await _baseService.InsertAsync(entityCreateDto);
            return  new DataResponse(entity, StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(UserTokenFilter))]
        public virtual async Task<DataResponse> PutAsync([FromBody] TEntityUpdateDto entityUpdateDto , Guid id)
        {
            var entity = await _baseService.UpdateAsync(entityUpdateDto , id);
            return new DataResponse(entity, StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(UserTokenFilter))]
        public virtual async Task<DataResponse> Delete(Guid id)
        {
            int rowEffected =  await _baseService.DeleteAsync(id);
            return new DataResponse(rowEffected, StatusCodes.Status200OK);
        }
    }
}

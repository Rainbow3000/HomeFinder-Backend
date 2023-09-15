
using HomeFinder.Core.Interface.Service;
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

        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _baseService.GetAllAsync();
            return StatusCode(200, entities);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id) {
            var entity = await _baseService.GetAsync(id);
            return StatusCode(200,entity); 
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] TEntityCreateDto entityCreateDto )
        {
            var entity = await _baseService.InsertAsync(entityCreateDto); 
            return StatusCode(200, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] TEntityUpdateDto entityUpdateDto , Guid id)
        {
            var entity = await _baseService.UpdateAsync(entityUpdateDto , id);
            return StatusCode(200, entity); ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _baseService.DeleteAsync(id);
            return StatusCode(200, "OK");
        }
    }
}

using HomeFinder.Core.DataResponse;
using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Filter;
using HomeFinder.Filter.Jwt;
using HomeFinder.Infrastructure.DataAccess;
using HomeFinder.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeFinder.Controllers
{

    [ApiController]
    public class CategorysController : BasesController<CategoryDto,CategoryCreateDto,CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly DatabaseContext _databaseContext;
        public CategorysController(ICategoryService categoryService, DatabaseContext databaseContext) : base(categoryService)
        {
            _categoryService = categoryService;
            _databaseContext = databaseContext;
        }

        [ServiceFilter(typeof(AdminTokenFilter))]
        public override Task<DataResponse> InsertAsync([FromBody] CategoryCreateDto entityCreateDto)
        {
            return base.InsertAsync(entityCreateDto);
        }

        [ServiceFilter(typeof(AdminTokenFilter))]
        public override Task<DataResponse> PutAsync([FromBody] CategoryUpdateDto entityUpdateDto, Guid id)
        {
            return base.PutAsync(entityUpdateDto, id);
        }

        [ServiceFilter(typeof(AdminTokenFilter))]
        public override Task<DataResponse> Delete(Guid id)
        {
            return base.Delete(id);
        }
    }
}

using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}

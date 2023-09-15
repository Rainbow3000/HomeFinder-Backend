using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class CategorysController : BasesController<CategoryDto,CategoryCreateDto,CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService; 
        public CategorysController(ICategoryService categoryService):base(categoryService){
            _categoryService = categoryService; 
        }
    }
}

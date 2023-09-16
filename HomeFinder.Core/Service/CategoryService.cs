using AutoMapper;
using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class CategoryService:BaseService<Category,CategoryDto,CategoryCreateDto,CategoryUpdateDto>,ICategoryService
    {
       // private readonly ICategoryRepository _categoryRepository;
       // private readonly IMapper _mapper; 
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper):base(categoryRepository,mapper)
        {
           // _categoryRepository = categoryRepository;
          
        }
    }
}

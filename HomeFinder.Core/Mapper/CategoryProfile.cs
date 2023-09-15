using AutoMapper;
using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() {

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>(); 
            CreateMap<CategoryUpdateDto,Category>(); 
        }
    }
}

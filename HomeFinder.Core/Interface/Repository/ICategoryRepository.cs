using HomeFinder.Core.Dto.Category;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Repository
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<List<Category>> GetListAsync(); 
    }
}

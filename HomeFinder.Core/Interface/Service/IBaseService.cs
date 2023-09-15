using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Service
{
    public interface IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        Task<List<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetAsync(Guid id);
        Task<TEntityDto> InsertAsync(TEntityCreateDto entityCreateDto);
        Task<TEntityDto> UpdateAsync(TEntityUpdateDto entityUpdateDto, Guid id);
        Task<int> DeleteAsync(Guid id);
    }
}

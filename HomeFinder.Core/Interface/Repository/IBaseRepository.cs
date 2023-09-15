using HomeFinder.Core.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Repository
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetAsync(string? sql, Guid id, Func<dynamic, TEntity> map);
        Task<List<TEntity>> GetAllAsync(string? sql, Func<dynamic, TEntity> map); 
        Task<int> DeleteAsync(string? sql,Guid id);
        Task<int> UpdateAsync(string? sql, List<SqlParameter> parameters, Guid id);
        Task<int> InsertAsync(string? sql,List<SqlParameter> parameters);
    }
}

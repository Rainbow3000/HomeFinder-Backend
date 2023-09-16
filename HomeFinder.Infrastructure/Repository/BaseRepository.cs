using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.Internal.Mappers;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Helper;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Infrastructure.DataAccess;
using HomeFinder.Infrastructure.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HomeFinder.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private string entityName = typeof(TEntity).Name;
        public BaseRepository(DatabaseContext databaseContext,IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper; 
        }

        public async Task<int> DeleteAsync(string sql,Guid id)
        {
            var entityName = typeof(TEntity).Name;
            SqlParameter sqlParameter = new SqlParameter($"@p_{entityName}Id", id); 
            int rowEffected = await _databaseContext.Database.ExecuteSqlRawAsync(sql+$" where [{entityName}Id] = @p_{entityName}Id"!,sqlParameter);
            return rowEffected;

        }

        public async Task<List<TEntity>> GetAllAsync(string? sql, Func<DbDataReader, TEntity> map)
        {
            using (var command = _databaseContext.Database.GetDbConnection().CreateCommand())
            {
                await _databaseContext.Database.OpenConnectionAsync();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                using (var result = await command.ExecuteReaderAsync())
                {
                    List<TEntity>? entities = new List<TEntity>();

                    while (await result.ReadAsync())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
            

        }

        public async Task<TEntity> GetAsync(string sql, Guid id , Func<DbDataReader, TEntity> map)
        {
            dynamic entity = null; 
            using (var command = _databaseContext.Database.GetDbConnection().CreateCommand())
            {
                await _databaseContext.Database.OpenConnectionAsync();
                string entityName = typeof(TEntity).Name; 
                command.CommandText = sql + $" where {entityName}Id = @p_{entityName}Id";
                command.CommandType = CommandType.Text;
                var parameter = new SqlParameter($"@p_{entityName}Id", id);
                command.Parameters.Add(parameter);
                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                       entity =  map(result); 
                    }
                }
            }
            return entity; 
        }

        public async Task<int> InsertAsync(string? sql, List<SqlParameter> parameters)
        {
            int rowEffected = await _databaseContext.Database.ExecuteSqlRawAsync(sql!, parameters);
            return rowEffected; 
        }

        public async Task<int> UpdateAsync(string? sql, List<SqlParameter> parameters,Guid id)
        {
            SqlParameter entityIdParams = new SqlParameter($"@p_{entityName}Id",id);
            var sqlUpdateQuery = sql + $" WHERE [{entityName}Id] = {entityIdParams}";
            int rowEffected = await _databaseContext.Database.ExecuteSqlRawAsync(sqlUpdateQuery, parameters);
            return rowEffected; 
        }
    }
}

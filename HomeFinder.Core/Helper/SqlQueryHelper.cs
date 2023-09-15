using HomeFinder.Core.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Helper
{
    public class SqlQueryHelper<TEntity>
    {
        public static string entityName = typeof(TEntity).Name;
        public static StringBuilder columnChunk = new StringBuilder();
        public static StringBuilder valueChunk = new StringBuilder();
        public static List<SqlParameter> parameters = new List<SqlParameter>() { };


        public static void ResetProperties()
        {
            columnChunk.Clear();
            valueChunk.Clear();
            parameters.Clear();
        }

        public static (string? sql, List<SqlParameter>) InsertSqlMethod(TEntity? entity)
        {
            SqlQueryHelper<TEntity>.ResetProperties(); 
            entity?.GetType().GetProperty($"{entityName}Id")?.SetValue(entity, Guid.NewGuid());
            entity?.GetType().GetProperties().ToList().ForEach(property =>
            {
                if (!ComplexTypeHelper.IsComplexType(property.PropertyType))
                {
                    var parameter = new SqlParameter($"@p_{property.Name}", property.GetValue(entity));
                    parameters.Add(parameter);
                    columnChunk.Append($",[{property.Name}]");
                    valueChunk.Append($",@p_{property.Name}");
                }
            });
            var columnString = columnChunk.Remove(0, 1);
            var valueString = valueChunk.Remove(0, 1);
            var sql = $"INSERT INTO {entityName} ({columnString}) VALUES ({valueString})";
            return (sql, parameters); 
        }

        public static (string sql , List<SqlParameter>) UpdateSqlMethod(TEntity? entity)
        {
            SqlQueryHelper<TEntity>.ResetProperties();
            var entityIdName = typeof(TEntity).Name; 
            entity?.GetType().GetProperties().ToList().ForEach(property =>
            {
                if(property.Name != entityIdName)
                {
                    if (!ComplexTypeHelper.IsComplexType(property.PropertyType))
                    {
                        var parameter = new SqlParameter($"@p_{property.Name}", property.GetValue(entity));
                        parameters.Add(parameter);
                        columnChunk.Append($",{property.Name} = @p_{property.Name}");
                    }
                }
            });
            var columnString = columnChunk.Remove(0, 1);
            string sql = $"UPDATE {entityName} SET " + columnString;
            return (sql, parameters);
        }

        public static string  GetSqlMethod()
        {
            string sql = $"SELECT * FROM {entityName}"; 
            return sql;
        }

        public static string DeleteSqlMethod()
        {
            string sql = $"DELETE FROM {entityName}";
            return sql;
        }
    }
}

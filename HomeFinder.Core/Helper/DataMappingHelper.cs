using AutoMapper;
using HomeFinder.Core.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HomeFinder.Core.Helper
{
    public class DataMappingHelper<TEntity>
    {

        public static TEntity? DataMapper(DbDataReader dataReader,IMapper _mapper)
        {
            if(dataReader == null)
            {
                throw new ArgumentNullException("Not Found");
            }
            dynamic entityMapper = null;
            string entityName = typeof(TEntity).Name; 
            if (entityName == typeof(Category).Name)
            {
                Category category = new Category();
                category.CategoryId = dataReader.GetGuid(0);
                category.Name = dataReader.GetString(1);
                category.Quantity = dataReader.GetInt32(2);
                category.Status = dataReader.GetInt32(3); 
                entityMapper = _mapper.Map<TEntity>(category)!;
            }else if(entityName == typeof(Home).Name)
            {
                Home home = new Home(); 
                home.HomeId =  dataReader.GetGuid(0);
                home.Name = dataReader.GetString(1);
                home.Description =  dataReader.GetString(2);
                home.Address =  dataReader.GetString(3);
                home.Rate = dataReader.GetInt32(4);
                home.Type = dataReader.SafeGetInt(5); 
                home.Status = dataReader.SafeGetInt(6);
                home.CategoryId =  dataReader.GetGuid(7);
                entityMapper = _mapper.Map<TEntity>(home)!;
            }
            else if(entityName == typeof(Room).Name)
            {

            }else if(entityName == typeof(User).Name)
            {

            }else if(entityName == typeof(Comment).Name)
            {

            }else if(entityName == typeof(Account).Name)
            {

            }else if(entityName == typeof(Order).Name)
            {

            }else if(entityName == typeof(OrderDetails).Name)
            {

            }

            return entityMapper; 
        } 
    }
}

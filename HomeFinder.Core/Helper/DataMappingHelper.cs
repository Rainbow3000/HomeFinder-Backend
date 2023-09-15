using AutoMapper;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Helper
{
    public class DataMappingHelper<TEntity>
    {
        public static TEntity? DataMapper(dynamic source,IMapper _mapper)
        {
            if(source == null)
            {
                throw new ArgumentNullException("Not Found");
            }
            dynamic entityMapper = null;
            string entityName = typeof(TEntity).Name; 
            if (entityName == typeof(Category).Name)
            {
                Category category = new Category();
                category.CategoryId = source.GetGuid(0);
                category.Name = source.GetString(1);
                category.Quantity = source.GetInt32(2);
                category.Status = source.GetInt32(3); 
                entityMapper = _mapper.Map<TEntity>(category)!;
            }else if(entityName == typeof(Home).Name)
            {

            }else if(entityName == typeof(Room).Name)
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

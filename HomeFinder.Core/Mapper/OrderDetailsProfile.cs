using AutoMapper;
using HomeFinder.Core.Dto.OrderDetails;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetails, OrderDetailsDto>();
            CreateMap<OrderDetailsUpdateDto, OrderDetails>();
            CreateMap<OrderDetailsCreateDto, OrderDetails>();
        }
    }
}

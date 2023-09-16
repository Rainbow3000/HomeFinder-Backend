using AutoMapper;
using HomeFinder.Core.Dto.Order;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderCreateDto, Order>();
        }
    }
}

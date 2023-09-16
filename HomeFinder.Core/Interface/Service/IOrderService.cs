using HomeFinder.Core.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Service
{
    public interface IOrderService : IBaseService<OrderDto, OrderCreateDto, OrderUpdateDto>
    {

    }
}

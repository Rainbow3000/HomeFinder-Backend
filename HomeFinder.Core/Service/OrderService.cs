using AutoMapper;
using HomeFinder.Core.Dto.Order;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class OrderService : BaseService<Order, OrderDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {
        // private readonly IOrderRepository _orderRepository;
        // private readonly IMapper _mapper; 
        public OrderService(IOrderRepository orderRepository, IMapper mapper) : base(orderRepository, mapper)
        {
            // _orderRepository = orderRepository;

        }
    }
}

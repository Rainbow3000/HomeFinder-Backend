using AutoMapper;
using HomeFinder.Core.Dto.OrderDetails;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class OrderDetailsService : BaseService<OrderDetails, OrderDetailsDto, OrderDetailsCreateDto, OrderDetailsUpdateDto>, IOrderDetailsService
    {
        // private readonly IOrderDetailsRepository _orderDetailsRepository;
        // private readonly IMapper _mapper; 
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IMapper mapper) : base(orderDetailsRepository, mapper)
        {
            // _orderDetailsRepository = orderDetailsRepository;

        }
    }
}

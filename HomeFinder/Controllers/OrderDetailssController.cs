using HomeFinder.Core.Dto.OrderDetails;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class OrderDetailssController : BasesController<OrderDetailsDto, OrderDetailsCreateDto, OrderDetailsUpdateDto>
    {
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly DatabaseContext _databaseContext;
        public OrderDetailssController(IOrderDetailsService orderDetailsService, DatabaseContext databaseContext) : base(orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
            _databaseContext = databaseContext;
        }
    }
}

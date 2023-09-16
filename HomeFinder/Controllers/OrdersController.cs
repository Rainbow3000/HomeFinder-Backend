using HomeFinder.Core.Dto.Order;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class OrdersController : BasesController<OrderDto, OrderCreateDto, OrderUpdateDto>
    {
        private readonly IOrderService _orderService;
        private readonly DatabaseContext _databaseContext;
        public OrdersController(IOrderService orderService, DatabaseContext databaseContext) : base(orderService)
        {
            _orderService = orderService;
            _databaseContext = databaseContext;
        }
    }
}

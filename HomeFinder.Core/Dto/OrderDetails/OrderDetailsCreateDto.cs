using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.OrderDetails
{
    public class OrderDetailsCreateDto:BaseDto
    {
        public Guid OrderId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string UserIdentity { get; set; }
        public string RoomName { get; set; }
        public double Price { get; set; }
        public string? Note { get; set; }
    }
}

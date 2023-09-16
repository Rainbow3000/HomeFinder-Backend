using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Order
{
    public class OrderUpdateDto:BaseDto
    {
        public Guid OrderId { get; set; }
        public Guid AccountId { get; set; }
        public Guid RoomId { get; set; }
        public int Status { get; set; }
    }
}

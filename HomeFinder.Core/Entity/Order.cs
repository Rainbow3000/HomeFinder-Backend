using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Entity
{
    public class Order:BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid AccountId { get; set; }
        public Guid RoomId { get; set; }
        public int Status { get; set; } 
        public Account Account { get; set; }
        public Room Room { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}

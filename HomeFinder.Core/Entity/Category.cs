using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Entity
{
    public class Category:BaseEntity

    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public ICollection<Home> Homes { get; set;}
    }
}

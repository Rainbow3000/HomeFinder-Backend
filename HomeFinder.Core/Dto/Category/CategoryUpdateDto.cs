using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Category
{
    public class CategoryUpdateDto:BaseDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}

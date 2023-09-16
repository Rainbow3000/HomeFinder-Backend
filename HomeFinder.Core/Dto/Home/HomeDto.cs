using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Home
{
    public class HomeDto:BaseDto
    {
        public Guid HomeId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int Rate { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public Guid CategoryId { get; set; }
    }
}

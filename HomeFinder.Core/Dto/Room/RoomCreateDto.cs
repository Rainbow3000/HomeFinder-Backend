using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Room
{
    public class RoomCreateDto:BaseDto
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double NewPrice { get; set; }
        public double OldPrice { get; set; }
        public int Status { get; set; }
        public string? Area { get; set; }
        public Guid HomeId { get; set; }
    }
}

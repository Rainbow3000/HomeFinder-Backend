using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Entity
{
    public class Home:BaseEntity
    {
        public Guid HomeId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int Rate { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Room> Rooms { get; set; }
        

    }
}

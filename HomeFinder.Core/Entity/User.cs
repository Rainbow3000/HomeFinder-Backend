using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Entity
{
    public class User:BaseEntity
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public string IdentityId { get; set; }
        public int? Age { get; set;}

        public Account Account { get; set; }
    }
}

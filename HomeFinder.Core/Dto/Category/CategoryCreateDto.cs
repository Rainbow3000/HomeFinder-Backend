using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Category
{
    public class CategoryCreateDto:BaseDto
    {
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Ten Bat Buoc")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
    }
}

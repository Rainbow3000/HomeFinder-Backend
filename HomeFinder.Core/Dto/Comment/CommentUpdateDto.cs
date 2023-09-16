using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Dto.Comment
{
    public class CommentUpdateDto:BaseDto
    {
        public Guid CommentId { get; set; }
        public string Message { get; set; }
        public Guid AccountId { get; set; }
        public Guid RoomId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
    }
}

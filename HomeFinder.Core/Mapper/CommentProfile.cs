using AutoMapper;
using HomeFinder.Core.Dto.Comment;
using HomeFinder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Mapper
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<CommentCreateDto, Comment>();
        }
    }
}

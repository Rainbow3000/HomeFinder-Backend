﻿using HomeFinder.Core.Dto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFinder.Core.Interface.Service
{
    public interface ICommentService : IBaseService<CommentDto, CommentCreateDto, CommentUpdateDto>
    {

    }
}

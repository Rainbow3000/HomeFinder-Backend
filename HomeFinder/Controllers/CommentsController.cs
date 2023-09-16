using HomeFinder.Core.Dto.Comment;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Service;
using HomeFinder.Core.Service;
using HomeFinder.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeFinder.Controllers
{
    [ApiController]
    public class CommentsController : BasesController<CommentDto, CommentCreateDto, CommentUpdateDto>
    {
        private readonly ICommentService _commentService;
        private readonly DatabaseContext _databaseContext;
        public CommentsController(ICommentService commentService, DatabaseContext databaseContext) : base(commentService)
        {
            _commentService = commentService;
            _databaseContext = databaseContext;
        }
    }
}

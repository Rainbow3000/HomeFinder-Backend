using AutoMapper;
using HomeFinder.Core.Dto.Comment;
using HomeFinder.Core.Entity;
using HomeFinder.Core.Interface.Repository;
using HomeFinder.Core.Interface.Service;

namespace HomeFinder.Core.Service
{
    public class CommentService : BaseService<Comment, CommentDto, CommentCreateDto, CommentUpdateDto>, ICommentService
    {
        // private readonly ICommentRepository _commentRepository;
        // private readonly IMapper _mapper; 
        public CommentService(ICommentRepository commentRepository, IMapper mapper) : base(commentRepository, mapper)
        {
            // _commentRepository = commentRepository;

        }
    }
}

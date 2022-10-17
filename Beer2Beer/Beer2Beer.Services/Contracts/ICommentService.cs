using Beer2Beer.DTO;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentCreateDto> CreateComment(CommentCreateDto commentDto);
        Task<CommentFullDto> UpdateComment(CommentFullDto commentDto);
        Task DeleteComment(int commentId, int useriD);
    }
}

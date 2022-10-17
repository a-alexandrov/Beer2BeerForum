using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync([FromBody] CommentCreateDto comment)
        {
            return new OkObjectResult(await this.commentService.CreateComment(comment));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] CommentFullDto comment)
        {
            return new OkObjectResult(await this.commentService.UpdateComment(comment));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(int commentId, int userId)
        {
            await this.commentService.DeleteComment(commentId, userId);
            return Ok();
        }
    }
}

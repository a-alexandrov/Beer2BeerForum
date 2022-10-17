using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK,
                    await this.commentService.CreateComment(comment));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, comment);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] CommentFullDto comment)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var updatedComment = new CommentFullDto();

            try
            {
                updatedComment = await this.commentService.UpdateComment(comment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, comment);
            }

            return StatusCode(StatusCodes.Status200OK, updatedComment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync(int commentId, int userId)
        {
            await this.commentService.DeleteComment(commentId, userId);
            return Ok();
        }
    }
}

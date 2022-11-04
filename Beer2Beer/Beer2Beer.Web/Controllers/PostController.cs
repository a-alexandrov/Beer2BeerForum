using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Web.Utility.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [Authorize(Policy = "UserStatus")]
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IAuthenticator authenticator;

        public PostController(IPostService postService,IAuthenticator authenticator)
        {
            this.postService = postService;
            this.authenticator = authenticator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery]PostQueryParameters parameters)
        {
            return new OkObjectResult(await this.postService.GetPosts(parameters));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return new OkObjectResult(await this.postService.GetPostById(id));
        }

        [HttpGet]
        [Route("latest")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestPosts(int count)
        {
            return new OkObjectResult(await this.postService.GetLatestPosts(count));
        }

        [HttpGet]
        [Route("mostCommented")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMostCommentedPost(int count)
        {
            return new OkObjectResult(await this.postService.GetPostsByMostComments(count));
        }

        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] PostCreateDto post)
        {
            return new OkObjectResult(await this.postService.CreatePost(post));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] PostUpdateDto postDto)
        {
            var loginID = await this.authenticator.GetCurrentUserID(this.User);
            return new OkObjectResult(await this.postService.UpdatePost(postDto,loginID));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
            var loginID = await this.authenticator.GetCurrentUserID(this.User);
            return new OkObjectResult(await this.postService.DeletePost(postId,loginID));
        }
    }
}
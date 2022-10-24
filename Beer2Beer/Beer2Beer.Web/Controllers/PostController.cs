using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
  //  [Authorize(Policy = "UserStatus")]
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestPosts(int count)
        {
            return new OkObjectResult(await this.postService.GetLatestPosts(count));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("mostCommented")]
        public async Task<IActionResult> GetMostCommentedPost(int count)
        {
            return new OkObjectResult(await this.postService.GetPostsByMostComments(count));
        }
        

        [HttpPost]
        public async Task<IActionResult> PostPost([FromQuery] PostCreateDto post)
        {
            return new OkObjectResult(await this.postService.CreatePost(post));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromQuery] PostUpdateDto postDto)
        {
            return new OkObjectResult(await this.postService.UpdatePost(postDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
            return new OkObjectResult(await this.postService.DeletePost(postId));
        }
    }
}
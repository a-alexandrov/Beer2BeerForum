using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public PostController(IPostService postService, IMapper mapper, IUserService userService)
        {
            this.postService = postService;
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetAllPosts());

        }
        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestPost()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetLatestPosts(10));
            
        }

        [HttpGet]
        [Route("mostCommented")]
        public async Task<IActionResult> GetMostCommented()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByMostComments(10));

        }

        [HttpGet]
        [Route("byId")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostById(id));

        }
        [HttpGet]
        [Route("byUserID")]
        public async Task<IActionResult> GetByUserId([FromQuery] int userID)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByUserID(userID));

        }
        
        [HttpPost]
        [Route("newPost")]
        public async Task<IActionResult> PostNew([FromQuery] PostCreateDto post)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.PostNewPost(post));
        }
        [HttpPut]
        [Route("change")]
        public async Task<IActionResult> Change([FromQuery] int postID, string newTitle, string content)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.ChangePost(postID, newTitle, content));

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.DeletePost(postId));

        }
    }
}

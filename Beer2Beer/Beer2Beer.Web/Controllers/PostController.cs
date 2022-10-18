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
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        public async Task<IActionResult> GetAll()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetAllPosts());

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestPosts()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetLatestPosts(10));
            
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("mostCommented")]
        public async Task<IActionResult> GetMostCommented()
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByMostComments(10));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("byId")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostById(id));

        }
        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("byUserID")]
        public async Task<IActionResult> GetByUserId([FromQuery] int userID)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByUserID(userID));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("keyword")]
        public async Task<IActionResult> GetByKeyword([FromQuery] string keyword)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByKeyword(keyword));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("likesAmount")]
        public async Task<IActionResult> GetByLikesRange([FromQuery] int min, int max)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByLikesRange(min, max));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("disikesAmount")]
        public async Task<IActionResult> GetByDisikesRange([FromQuery] int min, int max)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByDislikesRange(min, max));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("commentAmount")]
        public async Task<IActionResult> GetByCommentRange([FromQuery] int min, int max)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByCommentRange(min, max));

        }

        [HttpGet]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("createdAfter")]
        public async Task<IActionResult> GetByCreatonDate([FromQuery] DateTime createdAfter)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPostsByCreatonDate(createdAfter));

        }

        [HttpPost]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("newPost")]
        public async Task<IActionResult> PostNew([FromQuery] PostCreateDto post)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.PostNewPost(post));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("change")]
        public async Task<IActionResult> Change([FromQuery] int postID, string newTitle, string content,string tagName)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.ChangePost(postID, newTitle, content,tagName));

        }

        [HttpDelete]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("delete")]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.DeletePost(postId));

        }
    }
}
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


        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var posts = await this.postService.GetAllPosts();
                return this.StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (ArgumentNullException e)
            {

                return this.StatusCode(StatusCodes.Status400BadRequest, e.ParamName);
            }
        }
        [HttpGet]
        [Route("latest")]
        public async Task<IActionResult> GetLatestPost()
        {
            try
            {
                var posts = await this.postService.GetLatestPosts(10);
                return this.StatusCode(StatusCodes.Status200OK, posts);
            }
            catch (ArgumentNullException e)
            {

                return this.StatusCode(StatusCodes.Status400BadRequest, e.ParamName);
            }
        }

        [HttpGet]
        [Route("mostCommented")]
        public async Task<IActionResult> GetMostCommented()
        {
            try
            {
                var post = await this.postService.GetPostsByMostComments(10);
                return this.StatusCode(StatusCodes.Status200OK, post);
            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }

        [HttpGet]
        [Route("byId")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            try
            {
                var post = await this.postService.GetPostById(id);
                return this.StatusCode(StatusCodes.Status200OK, post);
            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }
        [HttpGet]
        [Route("byUserID")]
        public async Task<IActionResult> GetByUserId([FromQuery] int userID)
        {
            try
            {

                var posts = await this.postService.GetPostsByUserID(userID);
                return this.StatusCode(StatusCodes.Status200OK, posts);

            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }
        
        [HttpPost]
        [Route("newPost")]
        public async Task<IActionResult> PostNew([FromQuery] PostCreateDto post)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.PostNewPost(post));
        }
        [HttpPut]
        [Route("changeTitle")]
        public async Task<IActionResult> ChangeTitle([FromQuery] int postID, string newTitle)
        {
            try
            {

                var posts = await this.postService.ChangePostTitle(postID, newTitle);
                return this.StatusCode(StatusCodes.Status200OK, posts);

            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }

        [HttpPut]
        [Route("changeContent")]
        public async Task<IActionResult> ChangeContent([FromQuery] int postID, string newContent)
        {
            try
            {

                var posts = await this.postService.ChangePostContent(postID, newContent);
                return this.StatusCode(StatusCodes.Status200OK, posts);

            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
            try
            {

                var posts = await this.postService.DeletePost(postId);
                return this.StatusCode(StatusCodes.Status200OK, posts);

            }
            catch (ArgumentNullException e)
            {


                return this.StatusCode(StatusCodes.Status404NotFound, e.ParamName);
            }
        }
    }
}

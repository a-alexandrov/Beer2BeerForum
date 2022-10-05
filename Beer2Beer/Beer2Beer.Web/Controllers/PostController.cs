using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [Route ("latest")]
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

    }
}

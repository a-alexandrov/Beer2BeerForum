﻿using AutoMapper;
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
    [Authorize(Policy = "UserStatus")]
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
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.GetPosts(parameters));

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
        

        [HttpPost]
        [Route("newPost")]
        public async Task<IActionResult> PostNew([FromQuery] PostCreateDto post)
        {
            return this.StatusCode(StatusCodes.Status200OK, await this.postService.CreatePost(post));
        }

        [HttpPut]
        [Route("change")]
        public async Task<IActionResult> Change([FromQuery] int postID, string newTitle, string content,string tagName)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.UpdatePost(postID, newTitle, content,tagName));

        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletePost([FromQuery] int postId)
        {
                return this.StatusCode(StatusCodes.Status200OK, await this.postService.DeletePost(postId));

        }
    }
}
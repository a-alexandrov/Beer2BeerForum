﻿using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class PostService
    {

        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public PostService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<PostDto>> GetLastPosts(int count = 10)
        {
            var posts = await this.context.DbSet<Post>()
                .OrderByDescending(p => p.ID)
                .Take(count)
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetLatestPosts(int count = 10)
        {
            var posts = await this.context.DbSet<Post>()
                .OrderByDescending(p => p.CreatedOn)
                .Take(count)
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByMostComments(int count = 10)
        {
            var posts = await this.context.DbSet<Post>()
                .OrderByDescending(p => p.CommentsCount)
                .Take(count)
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetAllPosts()
        {
            var posts = await this.context.DbSet<Post>()
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<PostDto> ChangePostName(string newName)
        {
            //Unsure how to get current post
            var post = await this.context.DbSet<Post>()
                .ToListAsync();

            var postDto = mapper.Map<PostDto>(post);

            return postDto;
        }


    }
}

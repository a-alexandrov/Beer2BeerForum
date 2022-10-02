using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class PostService : IPostService
    {

        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public PostService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        #region GET
        public async Task<List<PostDto>> GetLatestPosts(int count = 10)
        {
            var posts = await this.context.Set<Post>()
                .OrderByDescending(p => p.CreatedOn)
                .Take(count)
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByMostComments(int count = 10)
        {
            var posts = await this.context.Set<Post>()
                .OrderByDescending(p => p.CommentsCount)
                .Take(count)
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetUserPosts(User user)
        {
            var posts = await this.context.Set<Post>().Where(post => post.UserID == user.ID).ToListAsync();
            var postDto = mapper.Map<List<PostDto>>(posts);
            return postDto;
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await this.context.Set<Post>().FirstOrDefaultAsync(post => post.ID == id);
            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<List<PostDto>> GetAllPosts()
        {
            var posts = await this.context.Set<Post>()
                .ToListAsync();

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }
        #endregion GET

        #region POST




    }
}

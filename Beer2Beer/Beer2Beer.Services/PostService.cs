using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class PostService : IPostService
    {

        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;
        private readonly IAdminService users;

        public PostService(IBeer2BeerDbContext context, IMapper mapper, IAdminService users)
        {
            this.context = context;
            this.mapper = mapper;
            this.users = users; 
        }


        #region GET
        public async Task<List<PostDto>> GetLatestPosts(int count = 10)
        {
            var posts = await this.context.Set<Post>()
                .OrderByDescending(p => p.CreatedOn)
                .Take(count)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByMostComments(int count = 10)
        {
            var posts = await this.context.Set<Post>()
                .OrderByDescending(p => p.CommentsCount)
                .Take(count)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByUserID(int userId)
        {
            var posts = await this.context.Set<Post>().Where(post => post.UserID == userId).ToListAsync();

            ArePostNull(posts);

            var postDto = mapper.Map<List<PostDto>>(posts);
            return postDto;
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await this.context.Set<Post>().FirstOrDefaultAsync(post => post.ID == id);

            IsPostNull(post);

            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<List<PostDto>> GetAllPosts()
        {
            var posts = await this.context.Set<Post>()
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }
        #endregion GET

        #region POST
        public async Task<PostDto> PostNewPost(PostCreateDto newPostDTO)
        {

            var postToAdd = mapper.Map<Post>(newPostDTO);
            this.context.Set<Post>().Add(postToAdd);
            await this.context.SaveChangesAsync();

            var posts = await this.context.Set<Post>().ToListAsync();
            var returnPost = mapper.Map<PostDto>(posts.Last());
            return returnPost;

        }
        #endregion POST 

        #region PUT
        public async Task<PostDto> ChangePostTitle(int postID, string newTitle)
        {
            var post = await this.context.Set<Post>().FirstOrDefaultAsync(post => post.ID == postID);

            IsPostNull(post);

            post.Title = newTitle;
            await this.context.SaveChangesAsync();

            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<PostDto> ChangePostContent(int postID, string content)
        {
            var post = await this.context.Set<Post>().FirstOrDefaultAsync(post => post.ID == postID);

            IsPostNull(post);
            
            post.Content = content;
            await this.context.SaveChangesAsync();

            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        //Tags???
        #endregion PUT

        #region DELETE
        public async Task<PostDto> DeletePost(int postID)
        {
            var postToRemove = this.context.Set<Post>().FirstOrDefault(post => post.ID == postID);
            
            IsPostNull(postToRemove);
            
            this.context.Set<Post>().Remove(postToRemove);
            await this.context.SaveChangesAsync();

            var postDto = mapper.Map<PostDto>(postToRemove);
            return postDto;
        }
        #endregion DELETE

        #region PrivateValidation
        private void IsPostNull(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("This post doesn't exist");
            }
        }

        private void ArePostNull(ICollection<Post> posts)
        {
            if (posts.Count == 0)
            {
                throw new ArgumentNullException("There are no posts to match the criteria");
            }
        }
        #endregion PrivateValidation

    }
}

using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
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
                .Where(x => !x.IsDeleted)
                .Take(count)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByMostComments(int count = 10)
        {
            var posts = await this.context.Set<Post>()
                .OrderByDescending(p => p.CommentsCount).Where(x => !x.IsDeleted)
                .Take(count)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }
        public async Task<PostDto> GetPostById(int id)
        {
            var post = await this.context.Set<Post>()
                .Where(x => !x.IsDeleted)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(post => post.ID == id);

            IsPostNull(post);

            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<List<PostDto>> GetPosts(PostQueryParameters parameters)
        {
            var posts = await this.FilterBy(parameters)
                    .Include(p => p.TagPosts)
                    .ThenInclude(tp => tp.Tag)
                    .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                    .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        #endregion GET

        #region POST
        public async Task<PostDto> CreatePost(PostCreateDto newPostDTO)
        {
            var postToAdd = mapper.Map<Post>(newPostDTO);
            this.context.Set<Post>().Add(postToAdd);
            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(postToAdd);
        }
        #endregion POST 

        #region PUT
        public async Task<PostDto> UpdatePost(int postID, string newTitle, string content, string tagName)
        {
            var post = await this.context.Set<Post>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(post => post.ID == postID);

            IsPostNull(post);

            post.Title = newTitle ?? post.Title;
            post.Content = content ?? post.Content;

            if (!String.IsNullOrEmpty(tagName))
            {
                Tag tag;
                if (!this.context.Set<Tag>().Any(t => t.Name == tagName))
                {
                    tag = await this.CreateTag(tagName);
                }
                else
                {
                    tag = await this.context.Set<Tag>().FirstOrDefaultAsync(t => t.Name == tagName);
                }

                var tagPost = new TagPost { PostID = post.ID, TagID = tag.ID };
                var tagExists = this.context
                    .Set<TagPost>()
                    .Any(tp => tp.TagID == tagPost.TagID
                    &&
                    tp.PostID == tagPost.PostID);
                if (!tagExists)
                {
                    this.context.Set<TagPost>().Add(tagPost);
                }


            }

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
            postToRemove.IsDeleted = true;
            this.context.Set<Post>().Update(postToRemove);
            await this.context.SaveChangesAsync();

            var postDto = mapper.Map<PostDto>(postToRemove);
            return postDto;
        }
        #endregion DELETE

        #region Private
        private void IsPostNull(Post post)
        {
            if (post == null)
            {
                throw new EntityNotFoundException("This post doesn't exist");
            }
        }

        private void ArePostNull(ICollection<Post> posts)
        {
            if (posts.Count == 0)
            {
                throw new EntityNotFoundException("There are no posts to match the criteria");
            }
        }

        private async Task<Tag> CreateTag(string tagName)
        {
            var tag = new Tag { Name = tagName };
            this.context.Set<Tag>().Add(tag);
            await this.context.SaveChangesAsync();

            return tag;
        }

        private IQueryable<Post> FilterBy(PostQueryParameters parameters)
        {
            var query = this.context.Set<Post>()
                .Where(p => !p.IsDeleted);

            if (parameters.UserId.HasValue)
            {
                query = query.Where(post => post.UserID == parameters.UserId);
            }
            if (!String.IsNullOrEmpty(parameters.Keyword))
            {
                query = query.Where(p => p.Title.Contains("") || p.Content.Contains("f"));
            }
            if (parameters.minLikes.HasValue)
            {
                query = query.Where(p => p.PostLikes >= parameters.minLikes);
            }
            if (parameters.maxLikes.HasValue)
            {
                query = query.Where(p => p.PostLikes <= parameters.maxLikes);
            }
            if (parameters.minDislikes.HasValue)
            {
                query = query.Where(p => p.PostDislikes >= parameters.minDislikes);
            }
            if (parameters.maxDislikes.HasValue)
            {
                query = query.Where(p => p.PostDislikes <= parameters.maxDislikes);
            }
            if (parameters.minComments.HasValue)
            {
                query = query.Where(p => p.CommentsCount >= parameters.minComments);
            }
            if (parameters.maxComments.HasValue)
            {
                query = query.Where(p => p.CommentsCount <= parameters.maxComments);
            }
            if (parameters.minDate.HasValue)
            {
                query = query.Where(p => p.CreatedOn >= parameters.minDate);
            }
            if (parameters.maxDate.HasValue) 
            {
                query = query.Where(p => p.CreatedOn <= parameters.maxDate);
            }
            return query;
        }
        #endregion Private


    }
}

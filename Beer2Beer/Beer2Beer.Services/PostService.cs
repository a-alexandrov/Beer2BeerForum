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
                .OrderByDescending(p => p.CreatedOn).Where(x => !x.IsDeleted)
                .Take(count)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
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
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<List<PostDto>> GetPostsByUserID(int userId)
        {
            var posts = await this.context.Set<Post>()
                .Where(post => post.UserID == userId && !post.IsDeleted)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .ToListAsync();

            ArePostNull(posts);

            var postDto = mapper.Map<List<PostDto>>(posts);
            return postDto;
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await this.context.Set<Post>()
                .Where(x => !x.IsDeleted)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .FirstOrDefaultAsync(post => post.ID == id);

            IsPostNull(post);

            var postDto = mapper.Map<PostDto>(post);
            return postDto;
        }

        public async Task<List<PostDto>> GetAllPosts()
        {
            var posts = await this.context.Set<Post>()
                .Where(x => !x.IsDeleted)
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }
        public async Task<List<PostDto>> GetPostsByKeyword(string keyword)
        {
            var posts = await this.context.Set<Post>()
                .Where(x => !x.IsDeleted && (x.Title.Contains(keyword) || x.Content.Contains(keyword)))
                .Include(p => p.TagPosts)
                .ThenInclude(tp => tp.Tag)
                .ToListAsync();

            ArePostNull(posts);

            posts.OrderBy(x => x.Title == keyword).ThenBy(x => x.Content == keyword);

            return mapper.Map<List<PostDto>>(posts);
        }

        public async Task<List<PostDto>> GetPostsByLikesRange(int minLikes, int maxLikes)
        {
            var posts = await this.context.Set<Post>()
               .Where(x => !x.IsDeleted && (x.PostLikes >= minLikes && x.PostLikes <= maxLikes))
               .Include(p => p.TagPosts)
               .ThenInclude(tp => tp.Tag)
               .ToListAsync();

            ArePostNull(posts);

            return mapper.Map<List<PostDto>>(posts.OrderBy(x => x.PostLikes));

        }

        public async Task<List<PostDto>> GetPostsByDislikesRange(int minDislikes, int maxDislikes)
        {
            var posts = await this.context.Set<Post>()
               .Where(x => !x.IsDeleted && (x.PostDislikes >= minDislikes && x.PostLikes <= maxDislikes))
               .Include(p => p.TagPosts)
               .ThenInclude(tp => tp.Tag)
               .ToListAsync();

            ArePostNull(posts);

            return mapper.Map<List<PostDto>>(posts.OrderBy(x => x.PostDislikes));

        }

        public async Task<List<PostDto>> GetPostsByCommentRange(int minComments, int maxComments)
        {
            var posts = await this.context.Set<Post>()
               .Where(x => !x.IsDeleted && (x.CommentsCount >= minComments && x.CommentsCount <= maxComments))
               .Include(p => p.TagPosts)
               .ThenInclude(tp => tp.Tag)
               .ToListAsync();

            ArePostNull(posts);

            return mapper.Map<List<PostDto>>(posts.OrderBy(x => x.CommentsCount));

        }

        public async Task<List<PostDto>> GetPostsByCreatonDate(DateTime createdAfter)
        {
            var posts = await this.context.Set<Post>()
               .Where(x => !x.IsDeleted && (x.CreatedOn.CompareTo(createdAfter) >= 0))
               .Include(p => p.TagPosts)
               .ThenInclude(tp => tp.Tag)
               .ToListAsync();

            ArePostNull(posts);

            return mapper.Map<List<PostDto>>(posts.OrderBy(x => x.CreatedOn));

        }

        #endregion GET

        #region POST
        public async Task<PostDto> PostNewPost(PostCreateDto newPostDTO)
        {

            var postToAdd = mapper.Map<Post>(newPostDTO);
            this.context.Set<Post>().Add(postToAdd);
            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(postToAdd);

        }
        #endregion POST 

        #region PUT
        public async Task<PostDto> ChangePost(int postID, string newTitle, string content, string tagName)
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
        #endregion Private


    }
}

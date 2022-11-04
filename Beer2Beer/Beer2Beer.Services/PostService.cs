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
                .Include(p => p.User)
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
                .Include(p=>p.User)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }

        public async Task<PostDto> GetPostById(int id)
        {
            var post = await this.context.Set<Post>()
                .Where(p => !p.IsDeleted)
                .Include(u => u.User)
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
                .Include(p=>p.User)
                .ToListAsync();

            ArePostNull(posts);

            var postDtos = mapper.Map<List<PostDto>>(posts);

            return postDtos;
        }
        public async Task<PostDto> CreatePost(PostCreateDto newPostDTO)
        {
            var postToAdd = mapper.Map<Post>(newPostDTO);
            this.context.Set<Post>().Add(postToAdd);
            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(postToAdd);
        }

        public async Task<PostDto> UpdatePost(PostUpdateDto dto, int loginID)
        {
            this.ValidateOwnership(dto.UserID, loginID);

            var post = await this.context.Set<Post>()
                .Where(p => !p.IsDeleted && p.ID == dto.ID)
                .FirstOrDefaultAsync();

            this.IsPostNull(post);

            post.Title = dto.Title ?? post.Title;
            post.Content = dto.Content ?? post.Content;

            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> UpdatePost(PostTagsUpdateDto tagsDto, int loginID)
        {
            this.ValidateOwnership(tagsDto.UserID, loginID);

            var post = await this.context.Set<Post>()
                .Where(p => !p.IsDeleted && p.UserID == tagsDto.UserID)
                .FirstOrDefaultAsync();

            this.IsPostNull(post);

            if (tagsDto.AreTagsToBeAdded)
            {
                this.AddTags(tagsDto.Tags);

                var tags = this.context.Set<Tag>()
                    .Where(t => tagsDto.Tags.Contains(t.Name))
                    .ToList();

                foreach (var tag in tags)
                {
                    var tagPost = new TagPost { PostID = post.ID, TagID = tag.ID };

                    var tagExists = this.context.Set<TagPost>()
                        .Any(tp => tp.TagID == tagPost.TagID
                        && tp.PostID == tagPost.PostID);

                    if (!tagExists)
                    {
                        this.context.Set<TagPost>().Add(tagPost);
                        post.TagPosts.Add(tagPost);
                    }
                }
            }
            else
            {
                this.RemoveTags(tagsDto.Tags, post);
            }

            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> DeletePost(int postID,int loginID)
        {
            this.ValidateOwnership(postID, loginID);

            var postToRemove = this.context.Set<Post>().FirstOrDefault(post => post.ID == postID);

            IsPostNull(postToRemove);
            postToRemove.IsDeleted = true;
            this.context.Set<Post>().Update(postToRemove);
            await this.context.SaveChangesAsync();

            var postDto = mapper.Map<PostDto>(postToRemove);
            return postDto;
        }

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

        private void AddTags(List<string> tags)
        {
            var tagMap = new HashSet<string>();
            var dbTags = this.context.Set<Tag>().Where(t => tagMap.Add(t.Name));

            foreach (var tag in tags)
            {
                if (string.IsNullOrEmpty(tag) || tagMap.Contains(tag))
                {
                    continue;
                }

                var tagToAdd = new Tag { Name = tag };

                this.context.Set<Tag>().Add(tagToAdd);
            }

            this.context.SaveChangesAsync();
        }

        private void RemoveTags(List<string> tags, Post post)
        {
            var tagPosts = this.context.Set<TagPost>().Where(tp => tags.Contains(tp.Tag.Name));

            foreach (var tag in tagPosts)
            {
                post.TagPosts.Remove(tag);
                this.context.Set<TagPost>().Remove(tag);
            }
        }

        private void ValidateOwnership(int postUserID, int loginID) {
            if (postUserID != loginID) {
                throw new InvalidActionException("You don't have access to this resource!");
            }
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
                query = query.Where(p => p.Title.Contains(parameters.Keyword) || p.Content.Contains(parameters.Keyword));
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
    }
}

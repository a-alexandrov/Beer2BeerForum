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
                .Include(p => p.Likes)
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
                .Include(p => p.Likes)
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

        public async Task<LikesDto> LikePost(PostLikeDto likeDto)
        {
            var post = await this.context.Set<Post>()
                .Where(p => !p.IsDeleted)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(post => post.ID == likeDto.PostId);

            var like = post.Likes.Where(l => l.UserId == likeDto.UserId).FirstOrDefault();

            
            if (like != null && likeDto.IsLiked != like.IsLiked)
            {
                like.IsLiked = likeDto.IsLiked;

                if (likeDto.IsLiked)
                {
                    post.PostDislikes--;
                    post.PostLikes++;
                }
                else
                {
                    post.PostDislikes++;
                    post.PostLikes--;
                }
            }
            else if (like == null)
            {
                var newLike = new Like
                {
                    UserId = likeDto.UserId,
                    PostID = post.ID,
                    IsLiked = likeDto.IsLiked
                };

                this.context.Set<Like>().Add(newLike);
                post.Likes.Add(newLike);

                if (likeDto.IsLiked)
                {
                    post.PostLikes++;
                }
                else
                {
                    post.PostDislikes++;
                }
            }

            this.context.Set<Post>().Update(post);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<LikesDto>(post);
        }

        public async Task<PostDto> UpdatePost(PostUpdateDto dto, int loginID, string role)
        {
            if(role != "Admin")
            {
                this.ValidateOwnership(dto.UserID, loginID);
            }

            var post = await this.context.Set<Post>()
                .Where(p => !p.IsDeleted && p.ID == dto.ID)
                .Include(p => p.TagPosts)
                    .ThenInclude(tp => tp.Tag)
                .FirstOrDefaultAsync();

            this.IsPostNull(post);

            post.Title = dto.Title ?? post.Title;
            post.Content = dto.Content ?? post.Content;

            if(dto.Tags != null)
            {
                // remove tags
                var tagPosts = await this.context.Set<TagPost>().ToListAsync();

                foreach (var oldTag in post.TagPosts)
                {
                    if (!dto.Tags.Contains(oldTag.Tag.Name))
                    {
                        tagPosts.Remove(oldTag);
                        post.TagPosts.Remove(oldTag);
                    }
                }

                //add tags
                var tags = await this.context.Set<Tag>().ToListAsync();

                foreach (var newTag in dto.Tags)
                {
                    var tag = tags.Where(t => t.Name == newTag).FirstOrDefault();

                    if (tag == null)
                    {
                        tag = new Tag { Name = newTag };
                        this.context.Set<Tag>().Add(tag);

                        var newTagPost = new TagPost { Tag = tag, PostID = post.ID };
                        this.context.Set<TagPost>().Add(newTagPost);
                        post.TagPosts.Add(newTagPost);
                    }
                    else if (!post.TagPosts.Where(tp => tp.TagID == tag.ID).Any())
                    {
                        var newTagPost = new TagPost { Tag = tag, PostID = post.ID };
                        this.context.Set<TagPost>().Add(newTagPost);
                        post.TagPosts.Add(newTagPost);
                    }
                }
            }

            await this.context.SaveChangesAsync();

            return mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> DeletePost(int postID,int loginID)
        {

            var postToRemove = this.context.Set<Post>().FirstOrDefault(post => post.ID == postID);

            this.ValidateOwnership(postToRemove.UserID, loginID);

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
            if (posts==null)
            {
                posts = new List<Post>();

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

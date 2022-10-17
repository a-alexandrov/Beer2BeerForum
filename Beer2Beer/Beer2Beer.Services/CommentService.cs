using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class CommentService : ICommentService
    {
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public CommentService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CommentCreateDto> CreateComment(CommentCreateDto commentDto)
        {
            var comment = mapper.Map<Comment>(commentDto);

            var postToComment = await this.context.Set<Post>()
                .Where(p => p.ID == commentDto.PostID).FirstOrDefaultAsync();

            if (postToComment == null)
            {
                throw new EntityNotFoundException(message: $"Post to comment with ID:{commentDto.PostID} not found.");
            }

            this.context.Set<Comment>().Add(comment);

            postToComment.CommentsCount++;

            await this.context.SaveChangesAsync();

            return mapper.Map<CommentCreateDto>(comment);
        }

        public async Task<CommentFullDto> UpdateComment(CommentUpdateDto commentDto)
        {
            var comment = await this.GetCommentById(commentDto.ID);

            if (comment == null)
            {
                throw new EntityNotFoundException(message: $"comment with ID:{commentDto.ID} not found.");
            }

            comment.Content = commentDto.Content ?? comment.Content;

            await this.context.SaveChangesAsync();

            return this.mapper.Map<CommentFullDto>(comment);
        }

        public async Task DeleteComment(int commentId, int userId)
        {
            var comment = await this.GetCommentById(commentId);

            if (comment == null)
            {
                throw new EntityNotFoundException(message: $"comment with ID:{commentId} not found.");
            }

            var user = await this.context.Set<User>()
                .Where(u => u.ID == userId)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new EntityNotFoundException(message: $"invalid user ID for comment with ID:{commentId}");
            }

            var post = await this.context.Set<Post>()
                .Where(p => p.ID == comment.PostID)
                .FirstOrDefaultAsync();

            if(comment.UserID == userId || user.IsAdmin)
            {
                comment.IsDeleted = true;
                post.CommentsCount--;
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidActionException("only the user who made the comment or an admin can delete it.");
            }
        }

        private async Task<Comment> GetCommentById(int id)
        {
            var comment = await this.context.Set<Comment>()
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(u => u.ID == id);

            return comment;
        }
    }
}

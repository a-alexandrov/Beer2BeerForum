using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
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
                throw new NullReferenceException(message: $"Post to comment with ID:{commentDto.PostID} not found.");
            }

            this.context.Set<Comment>().Add(comment);

            postToComment.CommentsCount++;

            await this.context.SaveChangesAsync();

            return mapper.Map<CommentCreateDto>(comment);
        }

        public async Task<CommentFullDto> UpdateComment(CommentFullDto commentDto)
        {
            var comment = await this.GetCommentById(commentDto.ID);

            if (commentDto == null)
            {
                throw new NullReferenceException(message: $"comment with ID:{commentDto.ID} not found.");
            }

            comment.Content = commentDto.Content ?? comment.Content;

            await this.context.SaveChangesAsync();

            return this.mapper.Map<CommentFullDto>(comment);
        }

        private async Task<Comment> GetCommentById(int id)
        {
            var comment = await this.context.Set<Comment>()
                .FirstOrDefaultAsync(u => u.ID == id);

            return comment;
        }
    }
}

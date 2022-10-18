using Beer2Beer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IPostService
    {
        Task<List<PostDto>> GetLatestPosts(int count);
        Task<List<PostDto>> GetPostsByMostComments(int count);
        Task<PostDto> GetPostById(int id);
        Task<List<PostDto>> GetPosts(PostQueryParameters parameters);
        Task<PostDto> CreatePost(PostCreateDto post);
        Task<PostDto> UpdatePost(PostUpdateDto dto);
        Task<PostDto> UpdatePost(PostTagsUpdateDto tagsDto);
        Task<PostDto> DeletePost(int postID);
    }
}

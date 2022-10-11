using Beer2Beer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IPostService
    {
        #region GET
        Task<List<PostDto>> GetLatestPosts(int count);
        Task<List<PostDto>> GetPostsByMostComments(int count);
        Task<List<PostDto>> GetPostsByUserID(int userId);
        Task<PostDto> GetPostById(int id);
        Task<List<PostDto>> GetAllPosts();
        #endregion GET

        #region POST
        Task<PostDto> PostNewPost(PostCreateDto post);
        #endregion POST 

        #region PUT
        Task<PostDto> ChangePost(int postID, string newTitle, string content);
        //Tags???
        #endregion PUT

        #region DELETE
        Task<PostDto> DeletePost(int postID);
        #endregion DELETE
    }
}

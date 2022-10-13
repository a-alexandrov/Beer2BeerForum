using Beer2Beer.DTO;
using System;
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
        Task<List<PostDto>> GetPostsByKeyword(string keyword);
        Task<List<PostDto>> GetPostsByLikesRange(int minLikes, int maxLikes);
        Task<List<PostDto>> GetPostsByDislikesRange(int minDislikes, int maxDislikes);
        Task<List<PostDto>> GetPostsByCommentRange(int minComments, int maxComments);
        Task<List<PostDto>> GetPostsByCreatonDate(DateTime createdAfter);


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

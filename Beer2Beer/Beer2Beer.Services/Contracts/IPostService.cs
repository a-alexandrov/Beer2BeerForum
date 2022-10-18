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
        Task<PostDto> GetPostById(int id);
        Task<List<PostDto>> GetPosts(PostQueryParameters parameters);


        #endregion GET

        #region POST
        Task<PostDto> CreatePost(PostCreateDto post);
        #endregion POST 

        #region PUT
        Task<PostDto> UpdatePost(int postID, string newTitle, string content,string tagName);
        //Tags???
        #endregion PUT

        #region DELETE
        Task<PostDto> DeletePost(int postID);
        #endregion DELETE
    }
}

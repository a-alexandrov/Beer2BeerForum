using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IPostService
    {
        #region GET
        Task<List<PostDto>> GetLatestPosts(int count);
        Task<List<PostDto>> GetPostsByMostComments(int count);
        Task<List<PostDto>> GetPostsByUserID(int userId);
        Task<List<PostDto>> GetPostsByUsername(string username);
        Task<PostDto> GetPostById(int id);
        Task<List<PostDto>> GetAllPosts();
        #endregion GET

        #region POST
        Task<PostDto> PostNewPost(PostCreateDto post);
        #endregion POST 

        #region PUT
        Task<PostDto> ChangePostTitle(int postID, string newTitle);

        Task<PostDto> ChangePostContent(int postID, string content);

        //Tags???
        #endregion PUT

        #region DELETE
        Task<PostDto> DeletePost(int postID);
        #endregion DELETE
    }
}

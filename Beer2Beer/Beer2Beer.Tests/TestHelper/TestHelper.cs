using Beer2Beer.DTO;
using Beer2Beer.Models;
using System.Collections.Generic;

namespace Beer2Beer.Tests.TestHelper
{
    public class TestHelper
    {
        public static User User
        {
            get
            {
                return new User
                {
                    ID = 1
                    ,
                    IsBlocked = false
                    ,
                    IsAdmin = false
                    ,
                    FirstName = "TestFirstName"
                    ,
                    LastName = "TestLastName"
                    ,
                    Email = "TestMail@test.com"
                    ,
                    Username = "TestUser"
                    ,
                    PasswordHash = "TestPassword"
                    ,
                    AvatarImage = null
                    ,
                    PhoneNumber = "8888888888888888"
                };
            }
        }

        public static UserUpdateDto UserUpdateDto
        {
            get
            {
                return new UserUpdateDto
                {
                    ID = 1
                    ,
                    FirstName = "NewTestName"
                    ,
                    LastName = "NewTestName"
                    ,
                    PasswordHash = "NewTestPassword"
                };
            }
        }

        public static CommentCreateDto CommentCreateDto
        {
            get
            {
                return new CommentCreateDto
                {
                    Content = "Test Comment Content"
                    ,
                    PostID = 1
                    ,
                    UserID = 1
                };
            }
        }

        public static Post Post
        {
            get
            {
                return new Post
                {
                    ID = 1,
                    Title = "TestTitle",
                    Content = "Test Post Content for testing purposes",
                    UserID = 1,
                    PostLikes = 1,
                    PostDislikes = 1,
                    CommentsCount = 1,
                    Comments = new List<Comment>()
                };
            }
        }

        public static Comment Comment
        {
            get
            {
                return new Comment
                {
                    ID = 2,
                    Content = "Test Comment Content",
                    UserID = 1,
                    User = User,
                    PostID = 1,
                    Post = Post
                };
            }
        }
    }
}

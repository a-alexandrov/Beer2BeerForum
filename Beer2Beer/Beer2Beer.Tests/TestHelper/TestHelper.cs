using Beer2Beer.DTO;
using Beer2Beer.Models;
using System;
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
                    CurrentUserId = 1
                    ,
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
                    Title = "VeryValidTestTitleForTesting",
                    Content = "Test Post Content for testing purposes - it absolutely contains more than 64 symbols, I really promise",
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


        public static PostCreateDto PostCreateDto
        {
            get
            {
                return new PostCreateDto
                {
                    UserID = 1,
                    Title = "VeryValidTestTitleForTesting",
                    Content = "Test Post Content for testing purposes - it absolutely contains more than 64 symbols, I really promise"

                };
            }

        }

        public static PostUpdateDto PostUpdateDto
        {
            get
            {
                return new PostUpdateDto
                {
                    ID = 1,
                    UserID = 1,
                    Title = "VeryValidTestTitleForTesting",
                    Content = "Test Post Content for testing purposes - it absolutely contains more than 64 symbols, I really promise",
                };

            }

        }

        public static PostQueryParameters EmptyQuery
        {
            get
            {
                return new PostQueryParameters();
            }
        }


        public static PostQueryParameters FullQuery
        {
            get
            {
                return new PostQueryParameters
                {
                    minComments = 0,
                    maxComments = 10000,
                    minLikes=0,
                    maxLikes=10000,
                    minDislikes=0,
                    maxDislikes=10000,
                    Keyword="Test",
                    UserId=1,
                    minDate=System.DateTime.MaxValue,
                    maxDate=System.DateTime.MinValue
                };
            }
        }


        public static PostQueryParameters NotFullQuery
        {
            get
            {
                return new PostQueryParameters
                {
                    minComments = 0,
                    maxComments = 10000,
                    Keyword = "Test",
                    UserId = 1

                };
            }
        }
    }
}

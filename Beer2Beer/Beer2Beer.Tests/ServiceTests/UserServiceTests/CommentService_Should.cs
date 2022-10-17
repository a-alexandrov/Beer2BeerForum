using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using QuizOverflow.Services.MappingProfiles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class CommentService_Should
    {
        [TestMethod]
        public async Task CreateComment_ShouldCreate_When_ParamAreValidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var commentCreateDto = TestHelper.TestHelper.CommentCreateDto;
            var post = TestHelper.TestHelper.Post;
            var comment = TestHelper.TestHelper.Comment;

            mapperMock.Setup(m => m.Map<Comment>(It.IsAny<CommentCreateDto>())).Returns(comment);
            var users = new List<Post> { post };
            var mock = users.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.Set<Comment>().Add(comment));
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.CreateComment(commentCreateDto);

            dbContextMock.Verify(x => x.Set<Comment>().Add(comment), Times.Once());
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task CreateComment_ShouldThrow_When_ParamAreInvalidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var commentCreateDto = TestHelper.TestHelper.CommentCreateDto;
            commentCreateDto.PostID = 2;
            var post = TestHelper.TestHelper.Post;
            var comment = TestHelper.TestHelper.Comment;

            mapperMock.Setup(m => m.Map<Comment>(It.IsAny<CommentCreateDto>())).Returns(comment);
            var users = new List<Post> { post };
            var mock = users.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.CreateComment(commentCreateDto);
        }

        [TestMethod]
        public async Task UpdateComment_ShouldUpdate_When_ParamAreValidAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var commentUpdateDto = new CommentUpdateDto { ID = 1, Content = "New Content to update with" };
            var comment = TestHelper.TestHelper.Comment;
            comment.ID = 1;

            var comments = new List<Comment> { comment };

            var mock = comments.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new CommentService(dbContextMock.Object, mapper);
            var result = await sut.UpdateComment(commentUpdateDto);

            Assert.AreEqual(commentUpdateDto.Content, result.Content);
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task UpdateComment_ShouldThrow_When_ParamAreInvalidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var commentUpdateDto = new CommentUpdateDto { ID = 1, Content = "New Content to update with" };
            var comment = TestHelper.TestHelper.Comment;
            var comments = new List<Comment> { comment };
            var mock = comments.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mock.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.UpdateComment(commentUpdateDto);
        }

        [TestMethod]
        public async Task DeleteComment_ShouldDelete_When_ParamAreValid()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var comment = TestHelper.TestHelper.Comment;
            var comments = new List<Comment> { comment };
            var mockComment = comments.AsQueryable().BuildMockDbSet();
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mockUser = users.AsQueryable().BuildMockDbSet();
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mockPost = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mockComment.Object);
            dbContextMock.Setup(x => x.Set<User>()).Returns(mockUser.Object);
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mockPost.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.DeleteComment(2, 1);

            Assert.IsTrue(comment.IsDeleted);
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task DeleteComment_ShouldThrow_When_CommentIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var comment = TestHelper.TestHelper.Comment;
            var comments = new List<Comment> { comment };
            var mockComment = comments.AsQueryable().BuildMockDbSet();
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mockUser = users.AsQueryable().BuildMockDbSet();
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mockPost = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mockComment.Object);
            dbContextMock.Setup(x => x.Set<User>()).Returns(mockUser.Object);
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mockPost.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.DeleteComment(3, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task DeleteComment_ShouldThrow_When_WrongUser()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var comment = TestHelper.TestHelper.Comment;
            var comments = new List<Comment> { comment };
            var mockComment = comments.AsQueryable().BuildMockDbSet();
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mockUser = users.AsQueryable().BuildMockDbSet();
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mockPost = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mockComment.Object);
            dbContextMock.Setup(x => x.Set<User>()).Returns(mockUser.Object);
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mockPost.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.DeleteComment(2, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidActionException))]
        public async Task DeleteComment_ShouldThrow_When_ParamAreInvalid()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var comment = TestHelper.TestHelper.Comment;
            comment.UserID = 2;
            var comments = new List<Comment> { comment };
            var mockComment = comments.AsQueryable().BuildMockDbSet();
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mockUser = users.AsQueryable().BuildMockDbSet();
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mockPost = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mockComment.Object);
            dbContextMock.Setup(x => x.Set<User>()).Returns(mockUser.Object);
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mockPost.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.DeleteComment(2, 1);
        }

        [TestMethod]
        public async Task DeleteComment_ShouldDelete_When_UserIsAdmin()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var comment = TestHelper.TestHelper.Comment;
            comment.UserID = 2;
            var comments = new List<Comment> { comment };
            var mockComment = comments.AsQueryable().BuildMockDbSet();
            var user = TestHelper.TestHelper.User;
            user.IsAdmin = true;
            var users = new List<User> { user };
            var mockUser = users.AsQueryable().BuildMockDbSet();
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mockPost = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<Comment>()).Returns(mockComment.Object);
            dbContextMock.Setup(x => x.Set<User>()).Returns(mockUser.Object);
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mockPost.Object);

            var sut = new CommentService(dbContextMock.Object, mapperMock.Object);
            await sut.DeleteComment(2, 1);

            Assert.IsTrue(comment.IsDeleted);
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}

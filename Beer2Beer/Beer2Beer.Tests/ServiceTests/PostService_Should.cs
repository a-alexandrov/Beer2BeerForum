using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using Beer2Beer.Services.MappingProfiles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class PostService_Should
    {
        [TestMethod]
        public void CreatePost_ShouldCreate_When_ParamAreValid()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var postCreateDto = new PostCreateDto();
            var post = TestHelper.TestHelper.Post;

            mapperMock.Setup(m => m.Map<Post>(It.IsAny<PostCreateDto>())).Returns(post);
            dbContextMock.Setup(x => x.Set<Post>().Add(post));
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);


            var sut = new PostService(dbContextMock.Object, mapperMock.Object);
            var result = sut.CreatePost(postCreateDto);

            dbContextMock.Verify(x => x.Set<Post>().Add(post), Times.Once());
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public void UpdatePost_ShouldUpdate_When_ParamAreValidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();


            var postUpdateDto = TestHelper.TestHelper.PostUpdateDto;
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, new Post { ID = 2 } };

            var mock = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(c => c.Set<Post>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new PostService(dbContextMock.Object, mapperMock.Object);
            var result = sut.UpdatePost(postUpdateDto,1);

            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public void UpdatePost_ShouldUpdate_When_ParamAreValidAndTitleIsNullAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var postUpdateDto = TestHelper.TestHelper.PostUpdateDto;
            postUpdateDto.Title = null;
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, new Post { ID = 2 } };

            var mock = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(c => c.Set<Post>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new PostService(dbContextMock.Object, mapperMock.Object);
            var result = sut.UpdatePost(postUpdateDto,1);

            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
        [TestMethod]
        public void UpdatePost_ShouldUpdate_When_ParamAreValidAndContentIsNullAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var postUpdateDto = TestHelper.TestHelper.PostUpdateDto;
            postUpdateDto.Content = null;
            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, new Post { ID = 2 } };

            var mock = posts.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(c => c.Set<Post>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new PostService(dbContextMock.Object, mapperMock.Object);
            var result = sut.UpdatePost(postUpdateDto,1);

            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetPosts_Should_FindPosts_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var query = TestHelper.TestHelper.EmptyQuery;


            var post = TestHelper.TestHelper.Post;
            var post2 = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post,post2};
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);


            var sut = new PostService(dbContextMock.Object, mapper);
            List<PostDto> result = await sut.GetPosts(query);

            Assert.AreEqual(result.Count,posts.Count);
        }

        [TestMethod]
        public async Task GetPosts_Should_FindPosts_When_QueryHasData()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var query = TestHelper.TestHelper.NotFullQuery;


            var post = TestHelper.TestHelper.Post;
            var post2 = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, post2 };
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);


            var sut = new PostService(dbContextMock.Object, mapper);
            List<PostDto> result = await sut.GetPosts(query);

            Assert.AreEqual(result.Count, posts.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task GetPostByID_Should_Throw_When_NoPostsFound()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var query = TestHelper.TestHelper.FullQuery;


            var post = TestHelper.TestHelper.Post;
            var post2 = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, post2 };
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);


            var sut = new PostService(dbContextMock.Object, mapper);
            List<PostDto> result = await sut.GetPosts(query);

            Assert.AreEqual(result.Count, posts.Count);
        }

        [TestMethod]
        public async Task GetPostByID_Should_FindPost_When_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var query = TestHelper.TestHelper.EmptyQuery;


            var post = TestHelper.TestHelper.Post;
            var post2 = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, post2 };
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);


            var sut = new PostService(dbContextMock.Object, mapper);
            var result = await sut.GetPostById(1);

            Assert.AreEqual(result.Content, post.Content);
        }

        [TestMethod]
        public async Task GetPostByID_Should_DeletePost_When_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var query = TestHelper.TestHelper.EmptyQuery;


            var post = TestHelper.TestHelper.Post;
            var post2 = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post, post2 };
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);


            var sut = new PostService(dbContextMock.Object, mapper);
            var result = await sut.DeletePost(1,1);

            Assert.AreEqual(result.ID, post.ID);
        }
    }
}

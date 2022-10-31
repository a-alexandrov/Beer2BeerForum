using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.Models;
using Beer2Beer.Services;
using Beer2Beer.Services.MappingProfiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests
{
    [TestClass]
    public class StatisticsService_Should
    {
        [TestMethod]
        public void TotalPostsCount_Should_Return_When_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var post = TestHelper.TestHelper.Post;
            var posts = new List<Post> { post };
            var mock = posts.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<Post>()).Returns(mock.Object);

            var sut = new StatisticsService(dbContextMock.Object);
            var taskResult = sut.TotalPostsCount();
            taskResult.Wait();
            
            Assert.IsTrue(taskResult.Result == 1);
        }

        [TestMethod]
        public void TotalUsersCount_Should_Return_When_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var post = TestHelper.TestHelper.User;
            var users = new List<User> { post };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new StatisticsService(dbContextMock.Object);
            var taskResult = sut.TotalUsersCount();
            taskResult.Wait();

            Assert.IsTrue(taskResult.Result == 1);
        }
    }
}

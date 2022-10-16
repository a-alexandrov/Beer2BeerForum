using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.Models;
using Beer2Beer.Services;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using QuizOverflow.Services.MappingProfiles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class LoginService_Should
    {
        [TestMethod]
        public async Task GetUser_Should_GetUser_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new LoginService(dbContextMock.Object, mapper);
            var result = await sut.GetUser(user.Email);

            Assert.IsTrue(result.Email == "TestMail@test.com");
        }


        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task GetUser_Should_Throw_WHen_UserIsNull()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var users = new List<User> { new User { ID = 2 } };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new LoginService(dbContextMock.Object, mapper);
            var result = await sut.GetUser("TestMail@test.com");
        }
    }
}

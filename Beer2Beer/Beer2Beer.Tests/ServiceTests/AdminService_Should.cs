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
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class AdminService_Should
    {
        [TestMethod]
        public async Task FindUserByUserName_Should_FindUser_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.FindUsersByUserName("TestUser");

            Assert.IsTrue(result[0].Username == "TestUser");
        }

        [TestMethod]
        public async Task FindUserByEmail_Should_FindUser_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.FindUsersByEmail("TestMail@test.com");

            Assert.IsTrue(result[0].Email == "TestMail@test.com");
        }

        [TestMethod]
        public async Task FindUsersByFirstName_Should_FindUser_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.FindUsersByFirstName("TestFirstName");

            Assert.IsTrue(result.FirstOrDefault().FirstName == "TestFirstName");
        }

        [TestMethod]
        public async Task FindUsersByFirstName_Should_ReturnEmptyList_WHen_ParamAreInvalid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.FindUsersByFirstName("invalid");

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public async Task Promote_Should_Promote_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.Promote("TestUser");

            Assert.IsTrue(result.IsAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidActionException))]
        public async Task Promote_Should_Throw_WHen_ParamAreInvalid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            user.IsAdmin = true;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.Promote("TestUser");
        }

        [TestMethod]
        public async Task Demote_Should_Demote_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            user.IsAdmin = true;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.Demote("TestUser");

            Assert.IsFalse(result.IsAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidActionException))]
        public async Task Demote_Should_Throw_WHen_ParamAreInvalid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.Demote("TestUser");
        }

        [TestMethod]
        public async Task BlockUser_Should_Block_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;

            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.BlockUser("TestUser");

            Assert.IsTrue(result.IsBlocked);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidActionException))]
        public async Task BlockUser_Should_Throw_WHen_ParamAreInvalid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            user.IsBlocked = true;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.BlockUser("TestUser");
        }

        [TestMethod]
        public async Task UnblockUser_Should_Unblock_WHen_ParamAreCorrect()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            user.IsBlocked = true;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.UnblockUser("TestUser");

            Assert.IsFalse(result.IsBlocked);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidActionException))]
        public async Task UnblockUser_Should_Throw_WHen_ParamAreInvalid()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.UnblockUser("TestUser");
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task UnblockUser_Should_Throw_WHen_UserNotFound()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);

            var sut = new AdminService(dbContextMock.Object, mapper);
            var result = await sut.UnblockUser("invalid");
        }
    }
}

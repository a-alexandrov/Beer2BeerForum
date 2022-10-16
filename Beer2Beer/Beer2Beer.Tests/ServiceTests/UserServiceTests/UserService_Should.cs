using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockQueryable.Moq;
using Moq;
using QuizOverflow.Services.MappingProfiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beer2Beer.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class UserService_Should
    {
        [TestMethod]
        public void CreateUser_ShouldCreate_When_ParamAreValid()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var userRegisterDto = new UserRegisterDto();
            var user = TestHelper.TestHelper.User;

            mapperMock.Setup(m => m.Map<User>(It.IsAny<UserRegisterDto>())).Returns(user);
            dbContextMock.Setup(x => x.Set<User>().Add(user));
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new UserService(dbContextMock.Object, mapperMock.Object);
            var result = sut.CreateUser(userRegisterDto);

            dbContextMock.Verify(x => x.Set<User>().Add(user), Times.Once());
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public async Task CreateUser_ShouldThrow_When_EmailIsInvalidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var userRegisterDto = new UserRegisterDto();
            var user = TestHelper.TestHelper.User;
            user.Email = "InvalidEmail";

            mapperMock.Setup(m => m.Map<User>(It.IsAny<UserRegisterDto>())).Returns(user);
            dbContextMock.Setup(x => x.Set<User>().Add(user));

            var sut = new UserService(dbContextMock.Object, mapperMock.Object);
            await sut.CreateUser(userRegisterDto);
        }

        [TestMethod]
        public void UpdateUser_ShouldUpdate_When_ParamAreValidAsync()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var userUpdateDto = TestHelper.TestHelper.UserUpdateDto;
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };

            var mock = users.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(c => c.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new UserService(dbContextMock.Object, mapperMock.Object);
            var result = sut.UpdateUser(userUpdateDto);

            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task UpdateUser_ShouldNotUpdate_When_ParamAreNullAsync()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var userUpdateDto = new UserUpdateDto { ID = 1 };
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };

            var mock = users.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var userUnderTest = It.IsAny<User>();

            var sut = new UserService(dbContextMock.Object, mapper);
            var result = await sut.UpdateUser(userUpdateDto);

            Assert.IsNotNull(result.FirstName);
            Assert.IsNotNull(result.LastName);
            Assert.IsNotNull(result.PasswordHash);
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task UpdateUser_ShouldThrow_When_IdIsInvalid()
        {
            var mapperMock = new Mock<IMapper>();
            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var userUpdateDto = new UserUpdateDto { ID = -1 };
            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };

            var mock = users.AsQueryable().BuildMockDbSet();

            dbContextMock.Setup(c => c.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var sut = new UserService(dbContextMock.Object, mapperMock.Object);
            var dto = await sut.UpdateUser(userUpdateDto);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public async Task UpdateUser_ShouldNotUpdateAvatar_When_ParamAreInvalid()
        {
            IFormFile nullFormFile = null;
            var dbContextMock = new Mock<IBeer2BeerDbContext>();
            var mapperMock = new Mock<IMapper>();

            var sut = new UserService(dbContextMock.Object, mapperMock.Object);
            await sut.UpdateUser(nullFormFile, 0);
        }

        [TestMethod]
        public async Task UpdateUser_ShouldUpdateAvatar_When_ParamAreValid()
        {
            var content = "Fake File content";
            var fileName = "test.png";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var formFile = new FormFile(
                     baseStream: stream,
                     baseStreamOffset: 0,
                     length: content.Length,
                     name: "Data",
                     fileName: fileName)
            {
                Headers = new HeaderDictionary()
            };
            formFile.ContentType = ".png";

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var initialInput = Encoding.ASCII.GetBytes(content);
            var sut = new UserService(dbContextMock.Object, mapper);
            var result = await sut.UpdateUser(formFile, 1);

            CollectionAssert.AreEqual(initialInput, result.AvatarImage);
            dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task UpdateUser_ShouldUThrow_When_UserIsNull()
        {
            var content = "Fake File content";
            var fileName = "test.png";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var formFile = new FormFile(
                     baseStream: stream,
                     baseStreamOffset: 0,
                     length: content.Length,
                     name: "Data",
                     fileName: fileName)
            {
                Headers = new HeaderDictionary()
            };
            formFile.ContentType = ".png";

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var users = new List<User> { new User { ID = 2 } };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var initialInput = Encoding.ASCII.GetBytes(content);
            var sut = new UserService(dbContextMock.Object, mapper);
            var result = await sut.UpdateUser(formFile, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public async Task UpdateUser_ShouldThrow_When_AvatarIsInvalid()
        {
            var content = "";
            var fileName = "test.png";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var formFile = new FormFile(
                     baseStream: stream,
                     baseStreamOffset: 0,
                     length: content.Length,
                     name: "Data",
                     fileName: fileName)
            {
                Headers = new HeaderDictionary()
            };
            formFile.ContentType = ".png";

            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = new Mapper(config);

            var dbContextMock = new Mock<IBeer2BeerDbContext>();

            var user = TestHelper.TestHelper.User;
            var users = new List<User> { user, new User { ID = 2 } };
            var mock = users.AsQueryable().BuildMockDbSet();
            dbContextMock.Setup(x => x.Set<User>()).Returns(mock.Object);
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var initialInput = Encoding.ASCII.GetBytes(content);
            var sut = new UserService(dbContextMock.Object, mapper);
            var result = await sut.UpdateUser(formFile, 1);

        }
    }
}

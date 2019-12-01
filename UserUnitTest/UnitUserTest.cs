using System;
using Xunit;
using Milestone1.Services;
using Milestone1.Models;
using System.Threading.Tasks;
using Moq;
using Milestone1.Interfaces;
using System.Collections.Generic;

namespace Milestone1.UserUnitTest
{
    public class UnitUserTest
    {
        List<User> users = new List<User>
            {
                  new User() { FullName = "test user 1", EmpCode="nurs@gmail.com",About="The best" },
                new User() { FullName = "test user 2",EmpCode="mads@gmail.com",About="The best of the best" },
            };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IUser>();
            var userService = new UserService(fakeRepository);

            var user = new User() { FullName = "test user 1", EmpCode = "nurs@gmail.com", About = "The best" };
            await userService.AddAndSave(user);
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var users = new List<User>
            {
                  new User() { FullName = "test user 1", EmpCode="nurs@gmail.com",About="The best" },
                new User() { FullName = "test user 2",EmpCode="mads@gmail.com",About="The best of the best" },
            };

            var fakeRepositoryMock = new Mock<IUser>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new UserService(fakeRepositoryMock.Object);

            var resultUsers = await userService.GetUsers();

            Assert.Collection(resultUsers, movie =>
            {
                Assert.Equal("test user 1", movie.FullName);
            },
            movie =>
            {
                Assert.Equal("test user 2", movie.FullName);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IUser>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var userService = new UserService(fakeRepositoryMock.Object);

            await userService.DeleteUser(2);
        }
    



}
}

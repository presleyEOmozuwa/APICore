using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.Controllers;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace APICore.APICore.UnitTests.Systems.Controllers
{
    public class TestAppUserController
    {

        [Fact]
        public async void Get_OnSucess_ReturnStatusCode200()
        {
            // Arrange
            var mockAppUsersRepo = new Mock<IAppUserRepository>();
            mockAppUsersRepo
                .Setup(repo => repo.GetUsers())
                .ReturnsAsync(AppUserFixture.GetUsers());

            var sut = new AppUserController(mockAppUsersRepo.Object);

            // Act
            var result = (OkObjectResult)await sut.GetUsers();

            // Assert
            result.StatusCode.Should().Be(200);
        }



        [Fact]
        public async void Get_OnSucess_InvokesAppUserRepositoryExactlyOnce()
        {
            // Arrange
            var mockAppUsersRepo = new Mock<IAppUserRepository>();
            mockAppUsersRepo
                .Setup(repo => repo.GetUsers())
                .ReturnsAsync(AppUserFixture.GetUsers());


            var sut = new AppUserController(mockAppUsersRepo.Object);

            // Act
            var result = await sut.GetUsers();

            // Assert
            mockAppUsersRepo.Verify(service => service.GetUsers(), Times.Once());
        }



        [Fact]
        public async void Get_OnSucess_ReturnListOfAppUsers()
        {
            // Arrange
            var mockAppUsersRepo = new Mock<IAppUserRepository>();
            mockAppUsersRepo
                .Setup(repo => repo.GetUsers())
                .ReturnsAsync(AppUserFixture.GetUsers());


            var sut = new AppUserController(mockAppUsersRepo.Object);

            // Act
            var result = await sut.GetUsers();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<AppUserModel>>();
        }


        [Fact]
        public async void Get_OnNoUserFound_Return404()
        {
            // Arrange
            var mockAppUsersRepo = new Mock<IAppUserRepository>();
            mockAppUsersRepo
                .Setup(repo => repo.GetUsers())
                .ReturnsAsync((List<ApplicationUser>)null);

            var sut = new AppUserController(mockAppUsersRepo.Object);

            // Act
            var result = await sut.GetUsers();


            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }







        //[Theory]
        //[InlineData("foo", 1)]
        //[InlineData("bar", 1)]
        //public void Test2(string input, int bar)
        //{

        //}
    }
}

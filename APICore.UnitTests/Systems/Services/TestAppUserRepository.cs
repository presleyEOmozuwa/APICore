using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;
using APICore.Repository;
using APICore.UnitTests.Fixtures;
using APICore.UnitTests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Xunit;

namespace APICore.UnitTests.Systems.Services
{
    public class TestAppUserRepository
    {
        [Fact]
        public async Task GetUsers_WhenCalled_InvokeHttpGetRequest()
        {
            // Arrange
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null).Object;
            //var mockUserManager = new Mock<UserManager<ApplicationUser>>().Object;
            var mockIhttpAccessor = new Mock<IHttpContextAccessor>().Object;
            var expectedResponse = AppUserFixture.GetUsers();
            string endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<ApplicationUser>.SetUpBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var config = Options.Create(new UserApiOptions()
            {
                Endpoint = endpoint
            });
            var sut = new AppUserRepository(mockUserManager, mockIhttpAccessor, httpClient, config);

            // Act
            await sut.GetUsers();

            // Assert
            handlerMock
              .Protected()
              .Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            // Arrange
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null).Object;
            //var mockUserManager = new Mock<UserManager<ApplicationUser>>().Object;
            var mockIhttpAccessor = new Mock<IHttpContextAccessor>().Object;
            var handlerMock = MockHttpMessageHandler<ApplicationUser>.SetUpReturn404();
            string endpoint = "https://example.com/users";
            var httpClient = new HttpClient(handlerMock.Object);
            var config = Options.Create(new UserApiOptions()
            {
                Endpoint = endpoint
            });
            var sut = new AppUserRepository(mockUserManager, mockIhttpAccessor, httpClient, config);

            // Act
            var result = await sut.GetUsers();

            // Assert
            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersExpectedSize()
        {
            // Arrange
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null).Object;
            //var mockUserManager = new Mock<UserManager<ApplicationUser>>().Object;
            var mockIhttpAccessor = new Mock<IHttpContextAccessor>().Object;
            var expectedResponse = AppUserFixture.GetUsers();
            string endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<ApplicationUser>.SetUpBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var config = Options.Create(new UserApiOptions()
            {
                Endpoint = endpoint
            });

            var sut = new AppUserRepository(mockUserManager, mockIhttpAccessor, httpClient, config);

            // Act
            var result = await sut.GetUsers();

            // Assert
            result.Count.Should().Be(expectedResponse.Count);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            // Arrange
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null).Object;
            //var mockUserManager = new Mock<UserManager<ApplicationUser>>().Object;
            var mockIhttpAccessor = new Mock<IHttpContextAccessor>().Object;
            var expectedResponse = AppUserFixture.GetUsers();
            string endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<ApplicationUser>.SetUpBasicGetResourceList(expectedResponse, endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UserApiOptions()
            {
                Endpoint = endpoint
            });

            var sut = new AppUserRepository(mockUserManager, mockIhttpAccessor, httpClient, config);

            // Act
            var result = await sut.GetUsers();
            var uri = new Uri(endpoint);

            // Assert
            handlerMock
              .Protected()
              .Verify("SendAsync", Times.Exactly(1),
              ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == uri),
              ItExpr.IsAny<CancellationToken>()
              );
        }
    }
}

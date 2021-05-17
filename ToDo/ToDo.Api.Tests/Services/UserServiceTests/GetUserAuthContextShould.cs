using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Api.Services;
using Xunit;

namespace ToDo.Api.Tests.Services.UserServiceTests
{
    public class GetUserAuthContextShould
    {
        [Fact]
        public void  ReturnPopulatedUsername()
        {
            var expectedUsername = Guid.NewGuid().ToString();
            var mockAccessor = new Mock<IHttpContextAccessor>();
            mockAccessor.SetupGet(x => x.HttpContext.User.Identity.Name).Returns(expectedUsername);
            var userService = new UserService(mockAccessor.Object);
            var authContext = userService.GetUserAuthContext();
            Assert.Equal(expectedUsername, authContext.UserName);
        }

        [Fact]
        public void ReturnPopulatedIsAuthenticated()
        {
            var mockAccessor = new Mock<IHttpContextAccessor>();
            mockAccessor.SetupGet(x => x.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            var userService = new UserService(mockAccessor.Object);
            var authContext = userService.GetUserAuthContext();
            Assert.True(authContext.IsAuthenticated);
        }

        [Fact]
        public void ReturnPopulatedUserId()
        {
            var expectedUserId = Guid.NewGuid();
            var mockAccessor = new Mock<IHttpContextAccessor>();
            var userService = new UserService(mockAccessor.Object);
            var authContext = userService.GetUserAuthContext();

            Assert.Equal(default, authContext.UniqueIdentifier);
        }
    }
}

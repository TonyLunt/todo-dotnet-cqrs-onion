using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Api;
using ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand;
using ToDo.Application.Features.ToDoLists.ViewModels;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoListEndpoints
{
    public class PutDescriptionShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList/Description";
        public PutDescriptionShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.True(response.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnUpdatedDescription()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(command.Description, response.ResponseModel.Description);
            }
        }

        [Fact]
        public async Task ReturnBadRequestIfDescriptionTooLong()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.Description = GetRandomString(2000);
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.BadRequest, response.HttpStatusCode);
            }
        }

        [Fact]
        public async Task ReturnNotFoundIfInvalidId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.Id = Guid.NewGuid();
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.NotFound, response.HttpStatusCode);
            }
        }

        private async Task<UpdateToDoListDescriptionCommand> GetCommand()
        {
            var existing = await GetExistingToDoList();
            return new UpdateToDoListDescriptionCommand()
            {
                Id = existing.Id,
                Description = Guid.NewGuid().ToString()
            };
        }
    }
}

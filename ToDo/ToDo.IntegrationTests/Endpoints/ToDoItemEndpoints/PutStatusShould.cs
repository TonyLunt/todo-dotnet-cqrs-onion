using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Api;
using ToDo.Application.Features.ToDoItems.Commands.UpdateToDoItemStatusCommand;
using ToDo.Application.Features.ToDoItems.ViewModels;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoItemEndpoints
{
    public class PutStatusShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoItem/Status";
        public PutStatusShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.True(response.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnUpdatedName()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(command.IsComplete, response.ResponseModel.IsComplete);
            }
        }

        [Fact]
        public async Task ReturnNotFoundIfInvalidId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.Id = Guid.NewGuid();
                var response = await Put<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.NotFound, response.HttpStatusCode);
            }
        }

        private async Task<UpdateToDoItemStatusCommand> GetCommand()
        {
            var existing = await GetExistingToDoItem();
            return new UpdateToDoItemStatusCommand()
            {
                Id = existing.Id,
                IsComplete = true
            };
        }
    }
}

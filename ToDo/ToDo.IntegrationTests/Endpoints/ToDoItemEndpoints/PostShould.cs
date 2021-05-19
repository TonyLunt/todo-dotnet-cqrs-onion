using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.Api;
using ToDo.Application.Features.ToDoItems.Commands.CreateToDoItemCommand;
using ToDo.Application.Features.ToDoItems.ViewModels;
using ToDo.Infra.Data;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoItemEndpoints
{
    public class PostShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoItem";
        public PostShould(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var testResponse = await Post<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.True(testResponse.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnPopulatedId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var testResponse = await Post<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.NotEqual(default, testResponse.ResponseModel.Id);
            }
        }

        [Fact]
        public async Task ReturnBadRequestIfNameTooLong()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.Name = GetRandomString(2000);
                var testResponse = await Post<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.BadRequest, testResponse.HttpStatusCode);
            }
        }

        [Fact]
        public async Task ReturnNotFoundIfInvalidToDoListId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.ToDoListId = Guid.NewGuid();
                var response = await Post<ToDoItemViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.NotFound, response.HttpStatusCode);
            }
        }

        private async Task<CreateToDoItemCommand> GetCommand()
        {
            var toDoList = await GetExistingToDoList();
            return new CreateToDoItemCommand()
            {
                Name = Guid.NewGuid().ToString(),
                ToDoListId = toDoList.Id
            };
        }

    }
}

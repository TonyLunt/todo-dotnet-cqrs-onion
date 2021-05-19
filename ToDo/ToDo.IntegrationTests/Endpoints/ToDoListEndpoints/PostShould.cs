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
using ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Infra.Data;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoListEndpoints
{
    public class PostShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList";
        public PostShould(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = GetCommand();
                var testResponse = await Post<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.True(testResponse.IsOk);
            }
        }

        [Fact]
        public async Task ReturnPopulatedId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = GetCommand();
                var testResponse = await Post<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.NotEqual(default, testResponse.ResponseModel.Id);
            }
        }

        [Fact]
        public async Task ReturnBadRequestIfNameTooLong()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = GetCommand();
                command.Name = GetRandomString(2000);
                var testResponse = await Post<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.BadRequest, testResponse.HttpStatusCode);
            }
        }

        [Fact]
        public async Task ReturnBadRequestIfDescriptionTooLong()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = GetCommand();
                command.Description = GetRandomString(2000);
                var testResponse = await Post<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(HttpStatusCode.BadRequest, testResponse.HttpStatusCode);
            }
        }

        private CreateToDoListCommand GetCommand()
        {
            return new CreateToDoListCommand()
            {
                Description = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
        }

    }
}

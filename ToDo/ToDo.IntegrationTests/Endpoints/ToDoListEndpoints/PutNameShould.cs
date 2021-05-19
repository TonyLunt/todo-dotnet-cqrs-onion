using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Api;
using ToDo.Application.Features.ToDoLists.Commands.RenameToDoListCommand;
using ToDo.Application.Features.ToDoLists.ViewModels;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoListEndpoints
{
    public class PutNameShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList/Name";
        public PutNameShould(WebApplicationFactory<Startup> factory) : base(factory)
        {
            
        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.True(response.IsOk);
            }
        }

        [Fact]
        public async Task ReturnUpdatedName()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                var response = await Put<ToDoListViewModel>(httpClient, _baseUrl, command);
                Assert.Equal(command.Name, response.ResponseModel.Name);
            }
        }

        [Fact]
        public async Task ReturnBadRequestIfNameTooLong()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var command = await GetCommand();
                command.Name = GetRandomString(2000);
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

        private async Task<RenameToDoListCommand> GetCommand()
        {
            var existing = await GetExistingToDoList();
            return new RenameToDoListCommand()
            {
                Id = existing.Id,
                Name = Guid.NewGuid().ToString()
            };
        }
    }
}

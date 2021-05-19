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
    public class DeleteShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList";
        public DeleteShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var toDoList = await GetExistingToDoList();
                var testResponse = await Delete(httpClient, $"{_baseUrl}/{toDoList.Id}");
                Assert.True(testResponse.IsSuccessStatusCode);
            }
        }

        [Fact]
        public async Task ReturnNotFoundIfValidId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var testResponse = await Delete(httpClient, $"{_baseUrl}/{Guid.NewGuid()}");
                Assert.Equal(HttpStatusCode.NotFound, testResponse.StatusCode);
            }
        }
    }
}
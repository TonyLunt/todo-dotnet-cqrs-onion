using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDo.Api;
using ToDo.Application.Features.ToDoItems.ViewModels;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoItemEndpoints
{
    public class GetByIdShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoItem";
        public GetByIdShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existingItem = await GetExistingToDoItem();

                var testResponse = await Get<ToDoItemViewModel>(httpClient, $"{_baseUrl}/{existingItem.Id}");

                Assert.True(testResponse.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnExpectedToDoItem()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existingItem = await GetExistingToDoItem();

                var testResponse = await Get<ToDoItemViewModel>(httpClient, $"{_baseUrl}/{existingItem.Id}");

                Assert.Equal(existingItem.Id, testResponse.ResponseModel.Id);
            }
        }

        [Fact]
        public async Task ReturnNotFoundForBadId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var testResponse = await Get<ToDoItemViewModel>(httpClient, $"{_baseUrl}/{Guid.NewGuid()}");

                Assert.Equal(HttpStatusCode.NotFound, testResponse.HttpStatusCode);
            }
        }
    }
}

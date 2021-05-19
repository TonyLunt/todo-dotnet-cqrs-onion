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
    public class GetForListShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoItem";
        public GetForListShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existingList = await GetExistingToDoList();

                var testResponse = await Get<IEnumerable<ToDoItemViewModel>>(httpClient, $"{_baseUrl}?toDoListId={existingList.Id}");

                Assert.True(testResponse.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnExpectedToDoItemsForList()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existingList = await GetExistingToDoList();
                
                var testResponse = await Get<IEnumerable<ToDoItemViewModel>>(httpClient, $"{_baseUrl}?toDoListId={existingList.Id}");

                Assert.All(existingList.ToDoItems, expected =>
                    Assert.Contains(testResponse.ResponseModel, response => response.Id == expected.Id
                    )
                );
            }
        }

        [Fact]
        public async Task ReturnNotFoundForInvalidId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var testResponse = await Get<IEnumerable<ToDoItemViewModel>>(httpClient, $"{_baseUrl}?toDoListId={Guid.NewGuid()}");

                Assert.Equal(HttpStatusCode.NotFound, testResponse.HttpStatusCode);
            }
        }
    }
}

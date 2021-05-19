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
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Domain.Entities;
using ToDo.Infra.Data;
using Xunit;

namespace ToDo.IntegrationTests.Endpoints.ToDoListEndpoints
{
    public class GetByIdShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList";
        public GetByIdShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existing = await GetExistingToDoList();
                var testResponse = await Get<ToDoListViewModel>(httpClient, $"{_baseUrl}/{existing.Id}");

                Assert.True(testResponse.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnToDoList()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var existing = await GetExistingToDoList();
                var testResponse = await Get<ToDoListViewModel>(httpClient, $"{_baseUrl}/{existing.Id}");

                Assert.Equal(existing.Id, testResponse.ResponseModel.Id);
            }
        }

        [Fact]
        public async Task ReturnNotFoundIfInvalidId()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var testResponse = await Get<ToDoListViewModel>(httpClient, $"{_baseUrl}/{Guid.NewGuid()}");

                Assert.Equal(HttpStatusCode.NotFound, testResponse.HttpStatusCode);
            }
        }
    }
}

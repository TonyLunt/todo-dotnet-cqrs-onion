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
   public class GetShould : BaseTestFixture
    {
        private readonly string _baseUrl = "/api/v1/ToDoList";
        public GetShould(WebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task ReturnOkResponse()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var testResponse = await Get<IEnumerable<ToDoListViewModel>>(httpClient, _baseUrl);

                Assert.True(testResponse.IsSuccess);
            }
        }

        [Fact]
        public async Task ReturnAllToDoLists()
        {
            using (var httpClient = GetHttpClient(AuthScenario.Authenticated))
            {
                var expectedToDoLists = new List<ToDoList>();
                for (int i = 0; i < 3; i++)
                {
                    expectedToDoLists.Add(await GetExistingToDoList());
                }

                var testResponse = await Get<IEnumerable<ToDoListViewModel>>(httpClient, _baseUrl);

                Assert.All(expectedToDoLists, expected => 
                    Assert.Contains(testResponse.ResponseModel, response => response.Id == expected.Id
                    )
                );
            }
        }
    }
}

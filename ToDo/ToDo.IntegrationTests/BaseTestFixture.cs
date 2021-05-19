using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo.Application.Services.UserService;
using ToDo.Domain.Entities;
using ToDo.Infra.Data;
using ToDo.Infra.Data.Tests.ToDoItemRepositoryTests.Setup;
using ToDo.IntegrationTests.AuthenticationHandlers;
using Xunit;

namespace ToDo.IntegrationTests
{
    public class BaseTestFixture : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        protected readonly WebApplicationFactory<Api.Startup> Factory;

        public BaseTestFixture(WebApplicationFactory<Api.Startup> factory)
        {
            Factory = factory;
        }

        protected HttpClient GetHttpClient(AuthScenario authScenario)
        {
            var client = Factory.WithWebHostBuilder(builder =>
            {
                switch (authScenario)
                {
                    case AuthScenario.Authenticated:
                        builder.ConfigureTestServices(services =>
                        {
                            services.AddAuthentication("Test")
                                .AddScheme<AuthenticationSchemeOptions, AuthenticatedAuthHandler>(
                                    "Test", options => { });
                        });
                        break;
                    default:
                        break;
                }
            })
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            return client;
        }

        protected ToDoContext GetDataContext()
        {
            var scope = (Factory.Services.GetRequiredService<IServiceScopeFactory>()).CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ToDoContext>();
            return context;
        }

        protected IUserService GetUserService()
        {
            var scope = (Factory.Services.GetRequiredService<IServiceScopeFactory>()).CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserService>();
            return service;
        }

        protected TEntity JsonDeserialize<TEntity>(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var responseModel = JsonSerializer.Deserialize<TEntity>(json, options);
            return responseModel;
        }

        protected async Task<TestResponse<TResponseModel>> Post<TResponseModel>(HttpClient httpClient, string url, object content) where TResponseModel : class
        {
            var contentJson = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, contentJson);
            return await GetTestResponse<TResponseModel>(response);
        }

        protected async Task<TestResponse<TResponseModel>> Put<TResponseModel>(HttpClient httpClient, string url, object content) where TResponseModel : class
        {
            var contentJson = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, contentJson);
            return await GetTestResponse<TResponseModel>(response);
        }

        protected async Task<HttpResponseMessage> Delete(HttpClient httpClient, string url)
        {
            return await httpClient.DeleteAsync(url);
        }

        protected async Task<TestResponse<TResponseModel>> Get<TResponseModel>(HttpClient httpClient, string url) where TResponseModel : class
        {
            var response = await httpClient.GetAsync(url);
            return await GetTestResponse<TResponseModel>(response);
        }

        private async Task<TestResponse<TResponseModel>> GetTestResponse<TResponseModel>(HttpResponseMessage response) where TResponseModel : class
        {
            var testResponse = new TestResponse<TResponseModel>()
            {
                HttpStatusCode = response.StatusCode,
                IsSuccess = response.IsSuccessStatusCode
            };
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var model = JsonDeserialize<TResponseModel>(responseContent);
                testResponse.ResponseModel = model;
            }
            return testResponse;
        }

        public static string GetRandomString(int length)
        {
            var returnVal = string.Empty;
            while (returnVal.Length < length)
            {
                returnVal += Guid.NewGuid().ToString();
            }
            return returnVal.Substring(0, length);
        }

        public async Task<ToDoList> GetExistingToDoList()
        {
            var toDoListFactory = new ToDoListFactory(GetDataContext(), GetUserService().GetUserAuthContext());
            return await toDoListFactory.GetPopulatedToDoList();
        }

        public async Task<ToDoItem> GetExistingToDoItem()
        {
            var toDoList = await GetExistingToDoList();
            return toDoList.ToDoItems.First();
        }
    }
}

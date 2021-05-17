using FizzWare.NBuilder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Api.Controllers;
using ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery;
using ToDo.Application.Features.ToDoLists.ViewModels;
using Xunit;

namespace ToDo.Api.Tests.Controllers.ToDoListsControllerTests
{
    public class GetShould
    {
        [Fact]
        public async Task ReturnListOfViewModels()
        {
            var expectedViewModels = Builder<ToDoListViewModel>.CreateListOfSize(3).Build().ToList();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(x => x.Send(It.IsAny<ListToDoListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedViewModels);
            var controller = new ToDoListController(mockMediator.Object);
            var response = await controller.Get();
            var okResult = (OkObjectResult)response.Result;
            Assert.Equal(expectedViewModels, okResult.Value);
        }
    }
}

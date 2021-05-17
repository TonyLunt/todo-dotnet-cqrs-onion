using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Queries.ListToDoListQueryTests
{
    public class ListToDoListQueryHandlerShould
    {
        [Fact]
        public async Task ReturnAllViewModels()
        {
            var expectedToDoList = Builder<ToDoList>.CreateListOfSize(3).Build().ToList();
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.List()).ReturnsAsync(expectedToDoList);
            var handler = new ListToDoListQueryHandler(mockRepository.Object, new Mock<ILogger<ListToDoListQueryHandler>>().Object);
            var viewModels = await handler.Handle(new ListToDoListQuery(), new System.Threading.CancellationToken());

            Assert.All(expectedToDoList, toDoList => Assert.Contains(viewModels, viewModel => viewModel.Id == toDoList.Id));
        }
    }
}

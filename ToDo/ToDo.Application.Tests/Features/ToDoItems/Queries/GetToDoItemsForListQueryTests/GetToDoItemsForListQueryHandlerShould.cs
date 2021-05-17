using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoItems;
using ToDo.Application.Features.ToDoItems.Queries.GetToDoItemsForListQuery;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.Queries.GetToDoItemsForListQueryTests
{
    public class GetToDoItemsForListQueryHandlerShould
    {
        [Fact]
        public async Task ReturnToDoItemViewModels()
        {
            var expectedViewModels = Builder<ToDoItem>.CreateListOfSize(3).Build().ToList();
            var mockToDoItemsRepository = new Mock<IToDoItemRepository>();
            mockToDoItemsRepository.Setup(x => x.GetForList(It.IsAny<Guid>())).ReturnsAsync(expectedViewModels);

            var mockToDoListRepository = new Mock<IRepository<ToDoList>>();
            var toDoList = Builder<ToDoList>.CreateNew().Build();
            mockToDoListRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(toDoList);
            var handler = new GetToDoItemsForListQueryHandler(mockToDoItemsRepository.Object, mockToDoListRepository.Object, new Mock<ILogger<GetToDoItemsForListQueryHandler>>().Object);
            var responseViewModels = await handler.Handle(new GetToDoItemsForListQuery(), new System.Threading.CancellationToken());
            Assert.All(responseViewModels, vm => Assert.Contains(expectedViewModels, expectedVm => expectedVm.Name == vm.Name));
        }

        [Fact]
        public async Task ThrowExceptionIfToDoListNotFound()
        {
            var mockToDoItemsRepository = new Mock<IToDoItemRepository>();

            var mockToDoListRepository = new Mock<IRepository<ToDoList>>();

            mockToDoListRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoList);
            var handler = new GetToDoItemsForListQueryHandler(mockToDoItemsRepository.Object, mockToDoListRepository.Object, new Mock<ILogger<GetToDoItemsForListQueryHandler>>().Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetToDoItemsForListQuery(), new System.Threading.CancellationToken()));
        }
    }
}

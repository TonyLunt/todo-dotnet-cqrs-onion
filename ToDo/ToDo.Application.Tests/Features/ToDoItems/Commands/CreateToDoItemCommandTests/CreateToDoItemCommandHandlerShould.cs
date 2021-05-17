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
using ToDo.Application.Features.ToDoItems.Commands.CreateToDoItemCommand;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.Commands.CreateToDoItemCommandTests
{
    public class CreateToDoItemCommandHandlerShould
    {
        [Fact]
        public async Task ReturnToDoItemViewModel()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Insert(It.IsAny<ToDoItem>())).ReturnsAsync(expectedToDoItem);

            var mockToDoListRepository = new Mock<IRepository<ToDoList>>();
            var expectedToDoList = Builder<ToDoList>.CreateNew().Build();
            mockToDoListRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoList);

            var handler = new CreateToDoItemCommandHandler(mockRepository.Object, mockToDoListRepository.Object, new Mock<ILogger<CreateToDoItemCommandHandler>>().Object);
            var response = await handler.Handle(new CreateToDoItemCommand(), new System.Threading.CancellationToken());
            Assert.Equal(expectedToDoItem.Name, response.Name);
        }

        [Fact]
        public async Task ThrowExceptionIfToDoListNotFound()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Insert(It.IsAny<ToDoItem>())).ReturnsAsync(expectedToDoItem);

            var mockToDoListRepository = new Mock<IRepository<ToDoList>>();
            mockToDoListRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoList);

            var handler = new CreateToDoItemCommandHandler(mockRepository.Object, mockToDoListRepository.Object, new Mock<ILogger<CreateToDoItemCommandHandler>>().Object);
            await Assert.ThrowsAsync<NotFoundException>(async() => await handler.Handle(new CreateToDoItemCommand(), new System.Threading.CancellationToken()));

        }
    }
}

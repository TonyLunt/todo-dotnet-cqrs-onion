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
using ToDo.Application.Features.ToDoItems.Commands.UpdateToDoItemStatusCommand;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.Commands.UpdateToDoItemStatusCommandTests
{
    public class UpdateToDoItemStatusCommandHandlerShould
    {
        [Fact]
        public async Task ReturnToDoItemViewModel()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoItem);
            mockRepository.Setup(x => x.Update(It.IsAny<ToDoItem>())).ReturnsAsync(expectedToDoItem);

            var handler = new UpdateToDoItemStatusCommandHandler(mockRepository.Object, new Mock<ILogger<UpdateToDoItemStatusCommandHandler>>().Object);
            var response = await handler.Handle(new UpdateToDoItemStatusCommand(), new System.Threading.CancellationToken());
            Assert.Equal(expectedToDoItem.Name, response.Name);
        }

        [Fact]
        public async Task ThrowExceptionIfToDoItemNotFound()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoItem);
            mockRepository.Setup(x => x.Update(It.IsAny<ToDoItem>())).ReturnsAsync(expectedToDoItem);

            var handler = new UpdateToDoItemStatusCommandHandler(mockRepository.Object, new Mock<ILogger<UpdateToDoItemStatusCommandHandler>>().Object);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateToDoItemStatusCommand(), new System.Threading.CancellationToken()));

        }
    }
}

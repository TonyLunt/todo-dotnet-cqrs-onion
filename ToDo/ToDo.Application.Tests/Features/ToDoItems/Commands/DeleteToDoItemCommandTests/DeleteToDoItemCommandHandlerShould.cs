using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoItems.Commands.DeleteToDoItemCommand;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.Commands.DeleteToDoItemCommandTests
{
    public class DeleteToDoItemCommandHandlerShould
    {
        [Fact]
        public async Task ReturnTrueForValidModel()
        {
            var mockRepository = new Mock<IRepository<ToDoItem>>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoItem);

            var handler = new DeleteToDoItemCommandHandler(mockRepository.Object, new Mock<ILogger<DeleteToDoItemCommandHandler>>().Object);
            var response = await handler.Handle(new DeleteToDoItemCommand(), new System.Threading.CancellationToken());
            Assert.True(response);
        }

        [Fact]
        public async Task ThrowExceptionIfToDoItemNotFound()
        {
            var mockRepository = new Mock<IRepository<ToDoItem>>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoItem);

            var handler = new DeleteToDoItemCommandHandler(mockRepository.Object, new Mock<ILogger<DeleteToDoItemCommandHandler>>().Object);
            await Assert.ThrowsAsync<NotFoundException>(async() => await handler.Handle(new DeleteToDoItemCommand(), new System.Threading.CancellationToken()));
        }
    }
}

using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoLists.Commands.DeleteToDoListCommand;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.DeleteToDoListCommandTests
{
    public class DeleteToDoListCommandHandlerShould
    {
        [Fact]
        public async Task ReturnViewModelIfValid()
        {
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(Builder<ToDoList>.CreateNew().Build());
            var handler = new DeleteToDoListCommandHandler(mockRepository.Object, new Mock<ILogger<DeleteToDoListCommandHandler>>().Object);

            var response = await handler.Handle(new DeleteToDoListCommand(), new System.Threading.CancellationToken());

            Assert.True(response);
        }

        [Fact]
        public async Task ThrowAsyncIfNotExists()
        {
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoList);
            var handler = new DeleteToDoListCommandHandler(mockRepository.Object, new Mock<ILogger<DeleteToDoListCommandHandler>>().Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteToDoListCommand(), new System.Threading.CancellationToken()));

        }
    }
}

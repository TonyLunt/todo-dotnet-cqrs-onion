using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommandTests
{
    public class UpdateToDoListDescriptionCommandHandlerShould
    {
        [Fact]
        public async Task ReturnViewModelIfValid()
        {
            var expectedToDoList = Builder<ToDoList>.CreateNew().Build();
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoList);
            mockRepository.Setup(x => x.Update(It.IsAny<ToDoList>())).ReturnsAsync(expectedToDoList);
            var handler = new UpdateToDoListDescriptionCommandHandler(mockRepository.Object, new Mock<ILogger<UpdateToDoListDescriptionCommandHandler>>().Object);

            var response = await handler.Handle(new UpdateToDoListDescriptionCommand(), new System.Threading.CancellationToken());

            Assert.Equal(response.Id, expectedToDoList.Id);
        }

        [Fact]
        public async Task ThrowAsyncIfNotExists()
        {
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoList);
            mockRepository.Setup(x => x.Update(It.IsAny<ToDoList>())).ReturnsAsync(null as ToDoList);
            var handler = new UpdateToDoListDescriptionCommandHandler(mockRepository.Object, new Mock<ILogger<UpdateToDoListDescriptionCommandHandler>>().Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateToDoListDescriptionCommand(), new System.Threading.CancellationToken()));
        }
    }
}

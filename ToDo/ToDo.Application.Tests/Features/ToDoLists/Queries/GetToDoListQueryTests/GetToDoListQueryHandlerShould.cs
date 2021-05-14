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
using ToDo.Application.Features.ToDoLists.Queries.GetToDoListQuery;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Queries.GetToDoListQueryTests
{
    public class GetToDoListQueryHandlerShould
    {
        [Fact]
        public async Task ReturnToDoListIfValid()
        {
            var expectedToDoList = Builder<ToDoList>.CreateNew().Build();
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoList);
            var handler = new GetToDoListQueryHandler(mockRepository.Object, new Mock<ILogger<GetToDoListQueryHandler>>().Object);

            var response = await handler.Handle(new GetToDoListQuery(), new System.Threading.CancellationToken());

            Assert.Equal(response.Id, expectedToDoList.Id);
        }

        [Fact]
        public async Task ThrowAsyncIfNotExists()
        {
            var mockRepository = new Mock<IRepository<ToDoList>>();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoList);
            mockRepository.Setup(x => x.Update(It.IsAny<ToDoList>())).ReturnsAsync(null as ToDoList);
            var handler = new GetToDoListQueryHandler(mockRepository.Object, new Mock<ILogger<GetToDoListQueryHandler>>().Object);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetToDoListQuery(), new System.Threading.CancellationToken()));
        }
    }
}

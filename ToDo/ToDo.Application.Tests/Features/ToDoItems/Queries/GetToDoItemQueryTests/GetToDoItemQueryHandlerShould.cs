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
using ToDo.Application.Features.ToDoItems.Queries.GetToDoItemQuery;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.Queries.GetToDoItemQueryTests
{
    public class GetToDoItemQueryHandlerShould
    {
        [Fact]
        public async Task ReturnCorrectViewModelForValidId()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(expectedToDoItem);

            var handler = new GetToDoItemQueryHandler(mockRepository.Object, new Mock<ILogger<GetToDoItemQueryHandler>>().Object);

            var response = await handler.Handle(new GetToDoItemQuery(), new System.Threading.CancellationToken());

            Assert.Equal(expectedToDoItem.Name, response.Name);
        }

        [Fact]
        public async Task ThrowExceptionIfToDoItemNotFound()
        {
            var mockRepository = new Mock<IToDoItemRepository>();
            var expectedToDoItem = Builder<ToDoItem>.CreateNew().Build();
            mockRepository.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as ToDoItem);

            var handler = new GetToDoItemQueryHandler(mockRepository.Object, new Mock<ILogger<GetToDoItemQueryHandler>>().Object);

            await Assert.ThrowsAsync<NotFoundException>(async() => await handler.Handle(new GetToDoItemQuery(), new System.Threading.CancellationToken()));

        }
    }
}

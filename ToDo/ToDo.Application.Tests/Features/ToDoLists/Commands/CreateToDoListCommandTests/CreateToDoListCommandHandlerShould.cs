using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.CreateToDoListCommandTests
{
    public class CreateToDoListCommandHandlerShould
    {
        [Fact]
        public async Task ReturnToDoListViewModel()
        {
            var mockRepository = new Mock<IRepository<ToDoList>>();
            var expectedViewModel = Builder<ToDoList>.CreateNew().Build();
            mockRepository.Setup(x => x.Insert(It.IsAny<ToDoList>())).ReturnsAsync(expectedViewModel);
            var handler = new CreateToDoListCommandHandler(mockRepository.Object, new Mock<ILogger<CreateToDoListCommandHandler>>().Object);
            var response = await handler.Handle(new CreateToDoListCommand(), new System.Threading.CancellationToken());
            Assert.Equal(expectedViewModel.Name, response.Name);
        }
    }
}

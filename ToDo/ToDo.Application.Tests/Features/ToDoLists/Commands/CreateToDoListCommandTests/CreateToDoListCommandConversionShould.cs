using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.Commands.CreateToDoListCommandTests
{
    public class CreateToDoListCommandConversionShould
    {
        [Fact]
        public void PopulateNameProperty()
        {
            var toDoListCommand = Builder<CreateToDoListCommand>.CreateNew().Build();
            ToDoList toDoList = (ToDoList)toDoListCommand;
            Assert.Equal(toDoListCommand.Name, toDoList.Name);
        }

        [Fact]
        public void PopulateDescriptionProperty()
        {
            var toDoListCommand = Builder<CreateToDoListCommand>.CreateNew().Build();
            ToDoList toDoList = (ToDoList)toDoListCommand;
            Assert.Equal(toDoListCommand.Description, toDoList.Description);
        }
    }
}

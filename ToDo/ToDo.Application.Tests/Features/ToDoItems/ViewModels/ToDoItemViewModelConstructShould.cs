using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;
using ToDo.Application.Tests.Common.ViewModels.BaseEntityViewModelTests;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoItems.ViewModels
{
    public class ToDoItemViewModelConstructShould : BaseEntityViewModelConstructShould<ToDoItem, ToDoItemViewModel>
    {
        [Fact]
        public void PopulateName()
        {
            var toDoItem = Builder<ToDoItem>.CreateNew().Build();
            var toDoItemVm = new ToDoItemViewModel(toDoItem);
            Assert.Equal(toDoItem.Name, toDoItemVm.Name);
        }

        [Fact]
        public void PopulateToDoListId()
        {
            var toDoItem = Builder<ToDoItem>.CreateNew().Build();
            var toDoItemVm = new ToDoItemViewModel(toDoItem);
            Assert.Equal(toDoItem.ToDoListId, toDoItemVm.ToDoListId);
        }
    }
}

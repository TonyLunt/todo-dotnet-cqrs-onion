using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Application.Tests.Common.ViewModels.BaseEntityViewModelTests;
using ToDo.Domain.Entities;
using Xunit;

namespace ToDo.Application.Tests.Features.ToDoLists.ViewModels.ToDoListViewModelTests
{
    public class ToDoListViewModelConstructShould : BaseEntityViewModelConstructShould<ToDoList, ToDoListViewModel>
    {
        [Fact]
        public void PopulateName()
        {
            var toDoList = Builder<ToDoList>.CreateNew().Build();
            var toDoListVm = new ToDoListViewModel(toDoList);
            Assert.Equal(toDoList.Name, toDoListVm.Name);
        }

        [Fact]
        public void PopulateDescription()
        {
            var toDoList = Builder<ToDoList>.CreateNew().Build();
            var toDoListVm = new ToDoListViewModel(toDoList);
            Assert.Equal(toDoList.Description, toDoListVm.Description);
        }
    }
}

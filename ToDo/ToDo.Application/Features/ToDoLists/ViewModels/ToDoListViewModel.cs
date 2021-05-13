using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoLists.ViewModels
{
    public class ToDoListViewModel : BaseEntityViewModel
    {
        public ToDoListViewModel()
        {

        }

        public ToDoListViewModel(ToDoList toDoList) : base(toDoList)
        {
            Name = toDoList.Name;
            Description = toDoList.Description;
        }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}

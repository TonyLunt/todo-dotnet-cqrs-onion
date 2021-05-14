using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Common.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.ViewModels
{
    public class ToDoItemViewModel : BaseEntityViewModel
    {
        public ToDoItemViewModel()
        {

        }

        public ToDoItemViewModel(ToDoItem toDoItem) : base(toDoItem)
        {
            Name = toDoItem.Name;
            IsComplete = toDoItem.IsComplete;
            ToDoListId = toDoItem.ToDoListId;
        }

        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public Guid ToDoListId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Application.Features.ToDoItems.Commands.UpdateToDoItemStatusCommand
{
    public class UpdateToDoItemStatusCommand : IRequest<ToDoItemViewModel>
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
    }
}

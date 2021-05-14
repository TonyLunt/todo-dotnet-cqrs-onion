using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Application.Features.ToDoItems.Commands.RenameToDoItemCommand
{
    public class RenameToDoItemCommand : IRequest<ToDoItemViewModel>
    {
        public Guid ToDoItemId { get; set; }
        public string Name { get; set; }
    }
}

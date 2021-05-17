using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.ToDoItems.Commands.DeleteToDoItemCommand
{
    public class DeleteToDoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

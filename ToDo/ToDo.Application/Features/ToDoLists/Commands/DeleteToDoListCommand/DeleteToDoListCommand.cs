using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Features.ToDoLists.Commands.DeleteToDoListCommand
{
    public class DeleteToDoListCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

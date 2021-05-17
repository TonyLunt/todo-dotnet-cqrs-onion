using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands.DeleteToDoItemCommand
{
    public class DeleteToDoItemCommandHandler : ToDoItemBaseHandler, IRequestHandler<DeleteToDoItemCommand, bool>
    {
        public DeleteToDoItemCommandHandler(IToDoItemRepository toDoItemRepository, ILogger<DeleteToDoItemCommandHandler> logger) : base(toDoItemRepository, logger)
        {
            
        }

        public async Task<bool> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await ToDoItemRepository.Get(request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoItem));
            }

            await ToDoItemRepository.Delete(request.Id);

            return true;
        }
    }
}

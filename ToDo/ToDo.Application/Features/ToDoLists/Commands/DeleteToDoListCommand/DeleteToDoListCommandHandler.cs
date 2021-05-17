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

namespace ToDo.Application.Features.ToDoLists.Commands.DeleteToDoListCommand
{
    public class DeleteToDoListCommandHandler : ToDoListBaseHandler, IRequestHandler<DeleteToDoListCommand, bool>
    {
        public DeleteToDoListCommandHandler(IRepository<ToDoList> toDoListRepository, ILogger<DeleteToDoListCommandHandler> logger) : base(toDoListRepository, logger)
        {
        }

        public async Task<bool> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Received request to delete ame To Do List {request.Id}");

            var toDoList = await ToDoListRepository.Get(request.Id);

            if (toDoList == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoList));
            }

            await ToDoListRepository.Delete(toDoList.Id);

            return true;
        }
    }
}

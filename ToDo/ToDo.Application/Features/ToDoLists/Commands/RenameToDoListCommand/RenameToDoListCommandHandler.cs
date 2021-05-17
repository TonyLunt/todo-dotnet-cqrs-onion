using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoLists.Commands.RenameToDoListCommand
{
    public class RenameToDoListCommandHandler : ToDoListBaseHandler, IRequestHandler<RenameToDoListCommand, ToDoListViewModel>
    {
        public RenameToDoListCommandHandler(IRepository<ToDoList> repository, ILogger<RenameToDoListCommandHandler> logger)
            : base(repository, logger)
        {

        }
        
        public async Task<ToDoListViewModel> Handle(RenameToDoListCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Received request to rename To Do List {request.Id} to {request.Name}");

            var toDoList = await ToDoListRepository.Get(request.Id);

            if (toDoList == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoList));
            }

            toDoList.Name = request.Name;

            var response = await ToDoListRepository.Update(toDoList);

            return new ToDoListViewModel(response);
        }
    }
}

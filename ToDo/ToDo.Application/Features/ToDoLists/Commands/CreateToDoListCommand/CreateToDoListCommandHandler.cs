using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand
{
    public class CreateToDoListCommandHandler : ToDoListBaseHandler, IRequestHandler<CreateToDoListCommand, ToDoListViewModel>
    {
        public CreateToDoListCommandHandler(IRepository<ToDoList> repository, ILogger<CreateToDoListCommandHandler> logger) : base(repository, logger)
        {

        }

        public async Task<ToDoListViewModel> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Received request to create To Do List {request.Name}");

            ToDoList newToDoList = (ToDoList)request;

            var response = await ToDoListRepository.Insert(newToDoList);

            return new ToDoListViewModel(response);
        }
    }
}

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

namespace ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand
{
    public class UpdateToDoListDescriptionCommandHandler : ToDoListBaseHandler, IRequestHandler<UpdateToDoListDescriptionCommand, ToDoListViewModel>
    {
        public UpdateToDoListDescriptionCommandHandler(IRepository<ToDoList> toDoListRepository, ILogger<UpdateToDoListDescriptionCommandHandler> logger) : base(toDoListRepository, logger)
        {
        }

        public async Task<ToDoListViewModel> Handle(UpdateToDoListDescriptionCommand request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Received request to update description for To Do List {request.Id} to {request.Description}");

            var toDoList = await ToDoListRepository.Get(request.Id);

            if (toDoList == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoList));
            }

            toDoList.Description = request.Description;

            var response = await ToDoListRepository.Update(toDoList);

            return new ToDoListViewModel(response);
        }
    }
}

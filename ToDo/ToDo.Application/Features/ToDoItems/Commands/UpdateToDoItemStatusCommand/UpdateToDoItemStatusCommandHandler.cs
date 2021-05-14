using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDo.Application.Common.Exceptions;
using ToDo.Application.Features.ToDoItems.ViewModels;
using ToDo.Application.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoItems.Commands.UpdateToDoItemStatusCommand
{
    public class UpdateToDoItemStatusCommandHandler : ToDoItemBaseHandler, IRequestHandler<UpdateToDoItemStatusCommand, ToDoItemViewModel>
    {
        public UpdateToDoItemStatusCommandHandler(IRepository<ToDoItem> toDoItemRepository, ILogger<UpdateToDoItemStatusCommandHandler> logger) : base(toDoItemRepository, logger)
        {
        }

        public async Task<ToDoItemViewModel> Handle(UpdateToDoItemStatusCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await ToDoItemRepository.Get(request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoItem));
            }
            toDoItem.IsComplete = request.IsComplete;

            var updateResponse = await ToDoItemRepository.Update(toDoItem);
            var viewModel = new ToDoItemViewModel(updateResponse);
            return viewModel;
        }
    }
}

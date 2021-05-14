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

namespace ToDo.Application.Features.ToDoItems.Commands.RenameToDoItemCommand
{
    public class RenameToDoItemCommandHandler : ToDoItemBaseHandler, IRequestHandler<RenameToDoItemCommand, ToDoItemViewModel>
    {
        public RenameToDoItemCommandHandler(IRepository<ToDoItem> toDoItemRepository, IRepository<ToDoList> toDoListRepository, ILogger<ToDoItemBaseHandler> logger) : base(toDoItemRepository, toDoListRepository, logger)
        {
        }

        public async Task<ToDoItemViewModel> Handle(RenameToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await ToDoItemRepository.Get(request.ToDoItemId);
            if (toDoItem == null)
            {
                throw new NotFoundException(request.ToDoItemId, typeof(ToDoItem));
            }
            toDoItem.Name = request.Name;

            var updateResponse = await ToDoItemRepository.Update(toDoItem);
            var viewModel = new ToDoItemViewModel(updateResponse);
            return viewModel;
        }
    }
}
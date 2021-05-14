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

namespace ToDo.Application.Features.ToDoItems.Commands.CreateToDoItemCommand
{
    public class CreateToDoItemCommandHandler : ToDoItemBaseHandler, IRequestHandler<CreateToDoItemCommand, ToDoItemViewModel>
    {
        public CreateToDoItemCommandHandler(IRepository<ToDoItem> toDoItemRepository, IRepository<ToDoList> toDoListepository, ILogger<CreateToDoItemCommandHandler> logger) 
            : base(toDoItemRepository, toDoListepository, logger)
        {
        }

        public async Task<ToDoItemViewModel> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var toDoList = await ToDoListRepository.Get(request.ToDoListId);
            if (toDoList == null)
            {
                throw new NotFoundException(toDoList.Id, typeof(ToDoList));
            }
            ToDoItem toDoItem = (ToDoItem)request;
            var createResponse = await ToDoItemRepository.Insert(toDoItem);
            var viewModel = new ToDoItemViewModel(createResponse);
            return viewModel;
        }
    }
}

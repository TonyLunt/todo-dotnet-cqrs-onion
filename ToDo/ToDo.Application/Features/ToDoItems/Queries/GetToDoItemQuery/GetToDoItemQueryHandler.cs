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

namespace ToDo.Application.Features.ToDoItems.Queries.GetToDoItemQuery
{
    public class GetToDoItemQueryHandler : ToDoItemBaseHandler, IRequestHandler<GetToDoItemQuery, ToDoItemViewModel>
    {
        public GetToDoItemQueryHandler(IToDoItemRepository toDoItemRepository, ILogger<GetToDoItemQueryHandler> logger) : base(toDoItemRepository, logger)
        {
        }

        public async Task<ToDoItemViewModel> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
        {
            var toDoItem = await ToDoItemRepository.Get(request.Id);
            if (toDoItem == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoItem));
            }

            return new ToDoItemViewModel(toDoItem);
        }
    }
}

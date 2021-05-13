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

namespace ToDo.Application.Features.ToDoLists.Queries.GetToDoListQuery
{
    public class GetToDoListQueryHandler : ToDoListBaseHandler, IRequestHandler<GetToDoListQuery, ToDoListViewModel>
    {
        public GetToDoListQueryHandler(IRepository<ToDoList> toDoListRepository, ILogger<GetToDoListQueryHandler> logger) : base(toDoListRepository, logger)
        {
        }

        public async Task<ToDoListViewModel> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"Received request for To Do List by ID: '{request.Id}'");

            var toDoList = await ToDoListRepository.Get(request.Id);

            if (toDoList == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoList));
            }

            return new ToDoListViewModel(toDoList);
        }
    }
}

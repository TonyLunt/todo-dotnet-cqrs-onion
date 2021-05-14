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

namespace ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery
{
    public class ListToDoListQueryHandler : ToDoListBaseHandler, IRequestHandler<ListToDoListQuery, IEnumerable<ToDoListViewModel>>
    {
        public ListToDoListQueryHandler(IRepository<ToDoList> toDoListRepository, ILogger<ListToDoListQueryHandler> logger) : base(toDoListRepository, logger)
        {
        }

        public async Task<IEnumerable<ToDoListViewModel>> Handle(ListToDoListQuery request, CancellationToken cancellationToken)
        {
            var toDoLists = await ToDoListRepository.List();
            var viewModels = toDoLists.Select(x => new ToDoListViewModel(x)).ToList();
            return viewModels;
        }
    }
}

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

namespace ToDo.Application.Features.ToDoItems.Queries.GetToDoItemsForListQuery
{
    public class GetToDoItemsForListQueryHandler : ToDoItemBaseHandler, IRequestHandler<GetToDoItemsForListQuery, IEnumerable<ToDoItemViewModel>>
    {
        private IRepository<ToDoList> _toDoListRepository;
        public GetToDoItemsForListQueryHandler(IToDoItemRepository toDoItemRepository, IRepository<ToDoList> toDoListRepository, ILogger<GetToDoItemsForListQueryHandler> logger) : base(toDoItemRepository, logger)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<IEnumerable<ToDoItemViewModel>> Handle(GetToDoItemsForListQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await _toDoListRepository.Get(request.Id);
            if (toDoList == null)
            {
                throw new NotFoundException(request.Id, typeof(ToDoList));
            }

            var toDoItems = await ToDoItemRepository.GetForList(toDoList.Id);
            var viewModels = toDoItems.Select(x => new ToDoItemViewModel(x)).ToList();
            return viewModels;
        }
    }
}

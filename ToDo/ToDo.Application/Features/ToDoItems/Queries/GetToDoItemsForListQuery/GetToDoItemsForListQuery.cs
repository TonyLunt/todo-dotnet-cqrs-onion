using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Application.Features.ToDoItems.Queries.GetToDoItemsForListQuery
{
    public class GetToDoItemsForListQuery : IRequest<IEnumerable<ToDoItemViewModel>>
    {
        public Guid Id { get; set; }
    }
}

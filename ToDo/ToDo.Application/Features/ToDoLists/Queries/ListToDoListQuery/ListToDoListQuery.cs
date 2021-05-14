using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Application.Features.ToDoLists.Queries.ListToDoListQuery
{
    public class ListToDoListQuery : IRequest<IEnumerable<ToDoListViewModel>>
    {
    }
}

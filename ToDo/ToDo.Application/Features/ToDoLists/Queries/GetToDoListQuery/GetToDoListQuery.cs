using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Application.Features.ToDoLists.Queries.GetToDoListQuery
{
    public class GetToDoListQuery : IRequest<ToDoListViewModel>
    {
        public Guid Id { get; set; }
    }
}

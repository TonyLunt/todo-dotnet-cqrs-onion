using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Application.Features.ToDoItems.Queries.GetToDoItemQuery
{
    public class GetToDoItemQuery : IRequest<ToDoItemViewModel>
    {
        public Guid Id { get; set; }
    }
}

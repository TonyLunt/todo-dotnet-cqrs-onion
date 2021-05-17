using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Application.Features.ToDoLists.Commands.UpdateToDoListDescriptionCommand
{
    public class UpdateToDoListDescriptionCommand : IRequest<ToDoListViewModel>
    {
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}

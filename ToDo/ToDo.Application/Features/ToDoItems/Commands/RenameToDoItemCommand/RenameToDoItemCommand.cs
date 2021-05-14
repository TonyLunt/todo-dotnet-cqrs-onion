using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoItems.ViewModels;

namespace ToDo.Application.Features.ToDoItems.Commands.RenameToDoItemCommand
{
    public class RenameToDoItemCommand : IRequest<ToDoItemViewModel>
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string Name { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;

namespace ToDo.Application.Features.ToDoLists.Commands.RenameToDoListCommand
{
    public class RenameToDoListCommand : IRequest<ToDoListViewModel>
    {
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

    }
}

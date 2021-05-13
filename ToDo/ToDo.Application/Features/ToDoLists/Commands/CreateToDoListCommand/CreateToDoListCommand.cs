using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Features.ToDoLists.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features.ToDoLists.Commands.CreateToDoListCommand
{
    public class CreateToDoListCommand : IRequest<ToDoListViewModel>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public static explicit operator ToDoList(CreateToDoListCommand command)
        {
            return new ToDoList()
            {
                Name = command.Name,
                Description = command.Description
            };
        }
    }
}
